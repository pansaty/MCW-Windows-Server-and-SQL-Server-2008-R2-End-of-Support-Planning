![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Windows-Server-and-SQL-Server-2008-R2-End-of-Support-Planning
</div>


<div class="MCWHeader2">
Hands-on lab step-by-step
</div>
<div class="MCWHeader3">
March 2019
</div>



Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents** 

<!-- TOC -->

- [\[insert workshop name here\] hands-on lab step-by-step](#\insert-workshop-name-here\-hands-on-lab-step-by-step)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Overview](#overview)
    - [Solution architecture](#solution-architecture)
    - [Requirements](#requirements)
    - [Before the hands-on lab](#before-the-hands-on-lab)
    - [Exercise 1: Failover the IIS machine using ASR](#Exercise-1:-Failover-the-IIS-machine-using-ASR)
        - [Task 1: Perform a test failover](#task-1-Perform-a-test-failover)
    - [Exercise 2: Recover SQL Server 2008 R2 to another region via Backup/Restore](#Exercise-2:-Recover-SQL-Server-2008-R2-to-another-region-via-Backup/Restore)
        - [Task 1: Create SQL Server 2008 R2 Machine](#task-1-Create-SQL-Server-2008 R2-Machine)
        - [Task 2: Task name](#task-2-task-name-1)
    - [Exercise 3: Exercise name](#exercise-3-exercise-name)
        - [Task 1: Task name](#task-1-task-name-2)
        - [Task 2: Task name](#task-2-task-name-2)
    - [After the hands-on lab](#after-the-hands-on-lab)
        - [Task 1: Task name](#task-1-task-name-3)
        - [Task 2: Task name](#task-2-task-name-3)

<!-- /TOC -->

# Windows Server and SQL Server 2008 R2 end of support planning hands-on lab step-by-step 

## Abstract and learning objectives 

In this lab you will be analyzing the ContosoFinance DB for compatibility issues with Azure SQLDB leveraging the Data Migration Assistant, fixing any issues and using the Data Migration Service to perform an Online migration from SQL Server 2008R2 to Azure SQLDB

## Overview

Contoso Finance runs their CRM solution on Windows 2008R2/ SQL 2008R2 on-premises. This application was developed inhouse and their team is looking to modernize to Azure, with minimal development changes but prefer to leverage PaaS vs IaaS. 

They have decided to **REFACTOR** the application in Azure to eliminate the need to continually upgrade/patch the application and DB Server and have decided to migrate to Azure WebApps and Azure SQLDB from IIS/SQL Server 2008R2

## Solution architecture

![Rehost](media/Refactor.png)

## Requirements

1.  Completed the [Before the HOL - Windows Server and SQL Server 2008 R2 EOS](https://github.com/pansaty/MCW-Windows-Server-and-SQL-Server-2008-R2-End-of-Support-Planning/blob/master/Hands-on%20lab/Before%20the%20HOL%20-%20Windows%20Server%20and%20SQL%20Server%202008%20R2%20EOS.md)

## Before the hands-on lab

Refer to the Before the hands-on lab setup guide manual before continuing to the lab exercises.

## Exercise 1: Analyze compatibility with the Data Migration Assistant (DMA)

Duration: 10 minutes

In this exercise we will check for and address compatibility issues with the ContosoFinance database using the DMA tool. During this lab we will only be assessing a single DB, however from the GUI you can select multiple databases from the same instance, or from the [command line](https://docs.microsoft.com/en-us/sql/dma/dma-commandline?view=sql-server-2017) you can perform an assessment across instances and leverage [PowerBI to consolidate Reports across instances](https://docs.microsoft.com/en-us/sql/dma/dma-consolidatereports?view=sql-server-2017). In addition if you are. You can also leverage DMA to [Identify the right Azure SQLDB SKU](https://docs.microsoft.com/en-us/sql/dma/dma-sku-recommend-sql-db?view=sql-server-2017)

### Task 1: Perform an Assessment to check for compatibility issues

1. RDP to the SQL Server 2008R2 VM you created in Before the Hands-On Lab

2. Download and install the Data Migration Assistant and launch

3. Click on the + New and use the following

   1. **Project Type:**  Assessment

   2. **Project Name:** ContosoFinance

   3. **Source server type:** SQL Server

   4. **Target server type:** Azure SQL Database. (Optionally, hit the dropdown and note the various target systems the tool supports)

      Click **Create**

4. On the **Options** page leave the defaults selected and click **Next**

5. On the **Select sources** page enter the public IP of the SQL Server or if running DMA locally you can use **localhost**. Since TLS is not configured, uncheck **Encrypt connection** and click **Connect**

6. Select the ContosoFinance database and click **Add**, then **Start Assessment**

7. After the Assessment is complete, review both the SQL Server feature parity report and compatibility issues. Although SSRS and SSAS are installing on the machine, they are not used

8. Under the Compatibility Issues note the Migration Blockers, we will correct in the next excercise.

   

## Exercise 2: Migrate database to Azure SQLDB

Duration: 30 minutes

In this exercise we will be migrating the schema and data for the ContosoFinance database from SQL Server 2008 R2 to Azure SQLDB.

### Task 1: Create a Logical SQL Server and Azure SQLDB to migrate to

1. Open a PowerShell command prompt and run the following to create a logical SQL Server and database to migrate to. When prompted enter your AAD credentials to login to your subscription

   `az login` 

   `az sql server create --resource-group ue_sqleoslab_rg --name ContosoFinance --admin-user sqladmin --admin-password P@ssw0rd1234 --location eastus`

   `az sql db create --name ContosoFinance --server ContosoFinance --resource-group ue_sqleoslab_rg --tier Basic` 

### Task 2: Perform a schema migration to Azure SQLDB

1. Relaunch the Database Migration Assistant

2. Click on the + New and use the following

   1. **Project Type:**  Migration

   2. **Project Name:** ContosoFinance

   3. **Source server type:** SQL Server

   4. **Target server type:** Azure SQL Database. 

   5. **Migration Scope:** Schema Only. Note for a simple small POC, you could leverage Schema and Data.

      Click **Create**

3. On the **Select sources** page enter the public IP of the SQL Server or if running DMA locally you can use **localhost**. Since TLS is not configured, uncheck **Encrypt connection** and click **Connect**

4. Select the ContosoFinance database and then click **Next**

5. On the **Select Target** page the Assessment is complete, review both the SQL Server feature parity report and compatibility issues. Although SSRS and SSAS are installing on the machine, they are not used

   *

### Task 3: Leverage the Data Migration Service to migrate data from  



### Task 4: Update ContosoFinance App Service to point newly migrated Azure SQLDB

### (Optional) Task 5: Test online migration

1. Make change in portal
2. Make change

## (Optional) Exercise 3: Security Features in Azure SQLDB to protect your Data

### Task 1: Enabling Dynamic Data Masking

### Task 2: Enabling Row Level Security



## After the hands-on lab 

Duration: 5 Minutes

After successfully completing this lab, to conserve cost, you can remove all resources created by deleting the resource group. If you prefer to retain the artifacts created as part of this lab do not proceed to the next task

### Task 1: Delete resource group

1. Open a PowerShell cmd prompt and run the following

   `az login` when prompted enter your credentiatls

   `az group delete --name ue_sqleoslab_rg `

You should follow all steps provided *after* attending the Hands-on lab.

