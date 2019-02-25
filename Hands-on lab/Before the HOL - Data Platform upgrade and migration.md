![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Data Platform upgrade and migration
</div>

<div class="MCWHeader2">
Before the hands-on lab setup guide
</div>

<div class="MCWHeader3">
December 2018
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

## Contents

- [Data Platform upgrade and migration before the hands-on lab setup guide](#data-platform-upgrade-and-migration-before-the-hands-on-lab-setup-guide)
  - [Requirements](#requirements)
  - [Before the hands-on lab](#before-the-hands-on-lab)
    - [Task 1: Provision a resource group](#task-1-provision-a-resource-group)
    - [Task 2: Create lab virtual machine](#task-2-create-lab-virtual-machine)
    - [Task 3: Create SQL Server 2017 virtual machine](#task-3-create-sql-server-2017-virtual-machine)
    - [Task 4: Create SQL Server 2008 R2 virtual machine](#task-4-create-sql-server-2008-r2-virtual-machine)
    - [Task 5: Connect to the Lab VM](#task-5-connect-to-the-lab-vm)
    - [Task 6: Add inbound port 1433 rule on the SqlServer2008R2 VM network security group](#task-6-add-inbound-port-1433-rule-on-the-sqlserver2008r2-vm-network-security-group)
    - [Task 7: Connect to the SqlServer2008R2 VM](#task-7-connect-to-the-sqlserver2008r2-vm)
    - [Task 8: Provision Azure SQL Database](#task-8-provision-azure-sql-database)
    - [Task 9: Register the Microsoft DataMigration resource provider](#task-9-register-the-microsoft-datamigration-resource-provider)
    - [Task 10: Create Azure Database Migration Service](#task-10-create-azure-database-migration-service)

# Data Platform upgrade and migration before the hands-on lab setup guide

## Requirements

- Microsoft Azure subscription must be pay-as-you-go or MSDN

  - Trial subscriptions will not work.
  
- A virtual machine configured with:

  - Visual Studio Community 2017 or later
  
  - Azure SDK 2.9 or later (Included with Visual Studio 2017)

## Before the hands-on lab

Duration: 45 minutes

In the Before the hands-on lab exercise, you will set up your environment for use in the rest of the hands-on lab. You should follow all the steps provided in the Before the hands-on lab section to prepare your environment **before attending** the hands-on lab. Failure to do so will significantly impact your ability to complete the lab within the time allowed.

> **Important**: Most Azure resources require unique names. Throughout this lab you will see the word “SUFFIX” as part of resource names. You should replace this with your Microsoft alias, initials, or another value to ensure the resource is uniquely named.

### Task 1: Provision a resource group

In this task, you will create an Azure resource group for the resources used throughout this lab.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups**, select **+Add**, then enter the following in the Create an empty resource group blade:

    - **Resource group name**: Enter hands-on-lab-SUFFIX.

    - **Subscription**: Select the subscription you are using for this hands-on lab.

    - **Resource group location**: Select the region you would like to use for resources in this hands-on lab. Remember this location so you can use it for the other resources you'll provision throughout this lab.

        ![Add Resource group Resource groups is highlighted in the navigation pane of the Azure portal, +Add is highlighted in the Resource groups blade, and "hands-on-labs" is entered into the Resource group name box on the Create an empty resource group blade.](./media/create-resource-group.png "Create resource group")

2. Select **Create**.

### Task 2: Create lab virtual machine

In this task, you will provision a virtual machine (VM) in Azure. The VM image used will have Visual Studio Community 2017 installed.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "visual studio community" into the Search the Marketplace box, select **Visual Studio Community 2017 (latest release) on Windows Server 2016 (x64)** from the results, and select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "visual studio community" is entered into the Search the Marketplace box. Visual Studio Community 2017 (latest release) on Windows Server 2016 (x64) is selected in the results.](./media/create-resource-visual-studio-on-windows-server-2016.png "Create Windows Server 2016 with Visual Studio Community 2017")

2. On the Create a virtual machine Basics tab, set the following configuration:

    - Project Details:

        - **Subscription**: Select the same subscription you are using for this hands-on lab.
        - **Resource Group**: Choose Use existing, and select the hands-on-lab-SUFFIX resource group.

    - Instance Details:

        - **Virtual machine name**: Enter LabVM.
        - **Region**: Select the region you are using for resources in this hands-on lab.
        - **Availability options**: Select no infrastructure redundancy required.
        - **Image**: Leave Visual Studio Community 2017 (latest release) on Windows Server 2016 (x64) selected.
        - **Size**: Accept the default size, Standard D2 v3.

    - Administrator Account:

        - **Username**: Enter **demouser**.
        - **Password**: Enter **Password.1!!**.

    - Inbound Port Rules

        - **Public inbound ports**: Choose Allow selected ports.
        - **Select inbound ports**: Select RDP (3389) in the list.

        ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/lab-virtual-machine-basics-tab.png "Create a virtual machine Basics tab")

    - Select **Next: Disks** to move to the next step.

3. On the Disks tab, set OS disk type to **Standard SSD**, and then select **Review + create**. Note, the remaining tabs can be skipped, and default values will be used.

    ![On the Create a virtual machine Disks tab, the OS disk type is set to Standard SSD.](media/lab-virtual-machine-disks-tab.png "Create a virtual machine Disks tab")

4. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

    ![The Review + create tab is displayed, with a Validation passed message.](media/lab-virtual-machine-review-create-tab.png "Create a virtual machine Review + create tab")

5. It may take 10+ minutes for the virtual machine to complete provisioning.

6. You can move on to the next task while waiting for the lab VM to provision.

### Task 3: Create SQL Server 2017 virtual machine

In this task, you will provision another virtual machine (VM) in Azure which will host your "on-premises" instance of SQL Server 2017 Enterprise.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "sql server 2017" into the Search the Marketplace box, select **SQL Server 2017 Enterprise Windows Server 2016** from the results, and select **Create**

    ![+ Create a resource is highlighted on the left side of the Azure portal, and at right, sql server 2017 and SQL Server 2017 Enterprise Windows Server 2016 are highlighted.](./media/create-resource-sql-server-2017.png "Azure portal")

2. On the Create virtual machine **Basics** tab, set the following configuration:

    - **Name**: Enter SqlServer2017.
    - **VM disk type**: Select Premium SSD.
    - **Username**: Enter **demouser**.
    - **Password**: Enter **Password.1!!**.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource group**: Select the hands-on-lab-SUFFIX resource group.
    - **Location**: Select the region you are using for resources in this hands-on lab.

        ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/sql-server-2017-create-vm-basics.png "Create SQL Server 2017 VM")

3. On the Create virtual machine **Size** tab, select DS1_v2 on the Choose a size screen, and then click *Select**.

    ![DS1_v2 is selectd on the Choose a size screen.](media/sql-server-2017-create-vm-size.png "Create SQL Server 2017 Size Tab")

4. On the Create virtual machine **Settings** tab, set the following:

    - **Select public inbound ports**: Select **RDP (3389)** in the list.
    - Select **OK**.

        ![In the Select public inbound ports dropdown, RDP (3389) is checked and highlighted.](media/sql-server-2017-create-vm-settings.png "Create SQL Server 2017 VM Settings Tab")

5. On the Create virtual machine **SQL Server settings** tab, set the following properties:

    - **SQL connectivity**: Select Public (Internet).
    - **Port**: Leave set to 1433.
    - **SQL Authentication**: Select Enable.
    - **Login name**: Enter demouser.
    - **Password**: Enter **Password.1!!**.
    - Select **OK**.

        ![The previously specified values are entered into the SQL Server Settings blade.](media/sql-server-2017-create-vm-sql-settings.png "Create SQL Server 2017 SQL Server Settings")

6. On the Create virtual machine **Summary** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

    ![The Summary tab is displayed, with a Validation passed message.](media/sql-server-2017-create-vm-summary.png "Create SQL Server 2017 VM Summary Tab")

7. It may take 10+ minutes for the virtual machine to complete provisioning.

8. You can move on to the next task while waiting for the SqlServer2017 VM to provision.

### Task 4: Create SQL Server 2008 R2 virtual machine

In this task, you will provision another virtual machine (VM) in Azure which will host your "on-premises" instance of SQL Server 2008 R2. The VM will use the SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2 image.

> **Note**:  An older version of Windows Server is being used because SQL Server 2008 R2 is not supported on Windows Server 2016.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "sql server 2008" into the Search the Marketplace box, select **SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2** from the results, and select **Create**.

    ![+ Create a resource is highlighted on the left side of the Azure portal, and at right, sql server 2008 and SQL Server 2008 R2 SP3 on Windows Server 2008 R2 are highlighted.](media/create-resource-sql-server-2008-r2.png "Create SQL Server 2008 R2 Resource")

2. On the Create a virtual machine Basics tab, set the following configuration:

    - Project Details:

        - **Subscription**: Select the same subscription you are using for this hands-on lab.
        - **Resource Group**: Select the hands-on-lab-SUFFIX resource group.

    - Instance Details:

        - **Virtual machine name**: Enter SqlServer2008R2.
        - **Region**: Select the region you are using for resources in this hands-on lab.
        - **Availability options**: Select no infrastructure redundancy required.
        - **Image**: Leave SQL Server 2008 R2 SP3 on Windows Server 2008 R2 selected.
        - **Size**: Accept the default size, Standard DS12 v2.

    - Administrator Account:

        - **Username**: Enter **demouser**.
        - **Password**: Enter **Password.1!!**.

    - Inbound Port Rules

        - **Public inbound ports**: Choose Allow selected ports.
        - **Select inbound ports**: Select RDP (3389) in the list.

        ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/sql-server-2008-r2-vm-basics-tab.png "Create a virtual machine Basics tab")

    - Select **Review + create** to move to the next step. Note, the remaining tabs can be skipped, and default values will be used.

3. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

    ![The Review + create tab is displayed, with a Validation passed message.](media/sql-server-2008-r2-vm-review-create-tab.png "Create a virtual machine Review + create tab")

4. It may take 10+ minutes for the virtual machine to complete provisioning.

5. You can move on to the next task while waiting for the SqlServer2008R2 VM to provision.

### Task 5: Connect to the Lab VM

In this task, you will create an RDP connection to your Lab virtual machine (VM), and disable Internet Explorer Enhanced Security Configuration.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

    ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

2. In the list of resources for your resource group, select the LabVM Virtual Machine.

    ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and LabVM is highlighted.](./media/resource-group-resources-labvm.png "LabVM in resource group list")

3. On your Lab VM blade, select Connect from the top menu.

    ![The LabVM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-labvm.png "Connect to LabVM")

4. Select **Download RDP file**, then open the downloaded RDP file.

    ![The Connect to virtual machine blade is displayed, and the Download RDP file button is highlighted.](./media/connect-to-virtual-machine.png "Connect to virtual machine")

5. Select **Connect** on the Remote Desktop Connection dialog.

    ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png "Remote Desktop Connection dialog")

6. Enter the following credentials when prompted:

    - **User name**: demouser
    - **Password**: Password.1!!

7. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

    ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-labvm.png "Remote Desktop Connection dialog")

8. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not start.

    ![The Server Manager tile is circled in the Start Menu.](./media/start-menu-server-manager.png "Server Manager tile in the Start menu")

9. Select **Local Server**, then select **On** next to **IE Enhanced Security Configuration**.

    ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-manager-ie-enhanced-security-configuration.png "Server Manager")

10. In the Internet Explorer Enhanced Security Configuration dialog, select **Off under Administrators**, then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/internet-explorer-enhanced-security-configuration-dialog.png "Internet Explorer Enhanced Security Configuration dialog box")

11. Close the Server Manager.

### Task 6: Add inbound port 1433 rule on the SqlServer2008R2 VM network security group

In this task, you will open port 1433 on the network security group associated with the SqlServer2008R2 VM to allow communication with SQL Server.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

    ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

2. In the list of resources for your resource group, select the SqlServer2008R2 VM.

    ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and SqlServer2008R2 is highlighted.](media/resource-group-resources-sqlserver2008r2.png "SqlServer2008R2 VM in resource group list")

3. On the SqlServer2008R2 blade, select **Networking** under Settings in the left-hand menu, and then select **Add inbound port rule**.

    ![Add inbound port rule is highlighted on the SqlServer2008R2 - Networking blade.](media/sql-virtual-machine-add-inbound-port-rule.png "SqlServer2008R2 - Networking blade")

4. On the **Add inbound security rule blade**, select **Basic** and then enter the following:

    - **Service**: Select MS SQL.
    - **Port ranges**: Value will be set to 1433.
    - **Priority**: Accept the default priority value.
    - **Name**: Enter SqlServer.

        ![On the Add inbound security rule dialog, MS SQL is selected for Service, port 1433 is selected, and the SqlServer is entered as the name.](media/sql-virtual-machine-add-inbound-security-rule-1433.png "Add MS SQL inbound security rule")

5. Select **Add**.

### Task 7: Connect to the SqlServer2008R2 VM

In this task, you will create an RDP connection to the SqlServer2008R2 VM, and add rules to the SqlServer2008R2 VM's Windows firewall to allow access to SQL Server via port 1433 by other machines.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

    ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

2. In the list of resources for your resource group, select the SqlServer2008R2 VM.

    ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and SqlServer2008R2 is highlighted.](media/resource-group-resources-sqlserver2008r2.png "SqlServer2008R2 VM in resource group list")

3. On the SqlServer2008R2 blade, select Connect from the top menu.

    ![The SqlServer2008R2 blade is displayed, with the Connect button highlighted in the top menu.](media/connect-sqlserver2008r2.png "Connect to SqlServer2008R2")

4. Select **Download RDP file**, then open the downloaded RDP file.

    ![The Connect to virtual machine blade is displayed, and the Download RDP file button is highlighted.](./media/connect-to-virtual-machine.png "Connect to virtual machine")

5. Select **Connect** on the Remote Desktop Connection dialog.

    ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png "Remote Desktop Connection dialog")

6. Enter the following credentials when prompted:

    - **User name**: demouser
    - **Password**: Password.1!!

7. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

    ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-sqlserver2008r2.png "Remote Desktop Connection dialog")

8. Once logged in, launch the **Server Manager**. This should open automatically, but you can access it via the task bar or Start menu if it does not start.

    ![The Server Manager tile is circled in the Start Menu's Administrative Tools menu, and in the task bar.](media/windows-server2008r2-start-menu.png "Windows Server 2008 R2 Start Menu")

9. In Server Manager, select **Configure IE ESC** in the Security Information section of the Server Summary.

    ![Configure IE ESC is highlighted in the Server Manager.](media/windows-server-2008r2-server-manager.png "Windows Server 2008 R2 Server Manager")

10. On the Internet Explorer Enhanced Security Configuration dialog, select **Off** under both Administrators and Users, and then select **OK**.

    ![Internet Explorer Enhanced Security Configuration dialog, with Off highlighted under both Administrators and Users.](media/windows-server-2008-ie-esc.png "Internet Explorer Enhanced Security Configuration dialog")

11. In Server Manager, expand **Configuration** and **Windows Firewall with Advanced Security**, and then right-click on **Inbound Rules** and select **New Rule...**

    ![In Server Manager, Configuration and Windows Firewall with Advanced Security are expanded, Inbound Rules is selected and New Rule is highlihgted in the pop-up menu.](media/windows-firewall-with-advanced-security-new-inbound-rule.png "Server Manager")

12. In the New Inbound Rule Wizard, under Rule Type, select **Port**, then select **Next**.

    ![Rule Type is selected and highlighted on the left side of the New Inbound Rule Wizard, and Port is selected and highlighted on the right.](media/windows-2008-new-inbound-rule-wizard-rule-type.png "Select Port")

13. In the Protocol and Ports dialog, use the default **TCP**, and enter **1433** in the Specific local ports text box, and then select **Next**.

    ![Protocol and Ports is selected on the left side of the New Inbound Rule Wizard, and 1433 is in the Specific local ports box, which is selected on the right.](media/windows-2008-new-inbound-rule-wizard-protocol-and-ports.png "Select a specific local port")

14. In the Action dialog, select **Allow the connection**, and then select **Next**.

    ![Action is selected on the left side of the New Inbound Rule Wizard, and Allow the connection is selected on the right.](media/windows-2008-new-inbound-rule-wizard-action.png "Specify the action")

15. In the Profile step, check **Domain**, **Private**, and **Public**, then select **Next**.

    ![Profile is selected on the left side of the New Inbound Rule Wizard, and Domain, Private, and Public are selected on the right.](media/windows-2008-new-inbound-rule-wizard-profile.png "Select Domain, Private, and Public")

16. In the Name screen, enter **SqlServer** for the name, and select **Finish**.

    ![Profile is selected on the left side of the New Inbound Rule Wizard, and sqlserver is in the Name box on the right.](media/windows-2008-new-inbound-rule-wizard-name.png "Specify the name")

17. Close the Server Manager.

### Task 8: Provision Azure SQL Database

In this task, you will create an Azure SQL Database, which will server as the target database for migration of the on-premises WorldWideImporters database into the cloud. The Premium tier is required to support ColumnStore index creation.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "sql database" into the Search the Marketplace box, select **SQL Database** from the results, and select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "sql database" is entered into the Search the Marketplace box. SQL Database is selected in the results.](media/create-resource-azure-sql-database.png "Create SQL Server")

2. On the SQL Database blade, enter the following:

    - **Database name**: Enter WorldWideImporters.

    - **Subscription**: Select the same subscription you are using for this hands-on lab.

    - **Resource Group**: Choose Use existing, and select the hands-on-lab-SUFFIX resource group.

    - **Select source**: Select Blank database.

    - **Server**: Select this, and select Create a new server, then on the New server blade, enter the following:
        - **Server name**: Enter a unique name, such as wwiSUFFIX.
        - **Server admin login**: Enter demouser.
        - **Password**: Enter Password.1!!
        - **Location**: Select the location you are using for resources in this hands-on lab.
        - **Allow Azure services to access server**: Ensure this is checked.
        - Select **OK**.

    - Under Want to use SQL elastic pool, select **Not now**.

    - **Pricing tier**: Select Premium P1: 125 DTUs, 500 GB, and select **Apply**.

        ![The Configure pricing tier for SQL Server is displayed, with Premium selected and highlighted.](media/azure-sql-database-pricing-tier-premium.png "SQL Pricing tier configuration")

    - **Collation**: Leave set to SQL_Latin1_General_CP1_CI_AS.

    ![The SQL Database blade is displayed, with the values specified above entered into the appropriate fields.](media/azure-sql-database-create.png "Create Azure SQL Database")

3. Select **Create**.

    > **Note**: The [Azure SQL Database firewall](https://docs.microsoft.com/azure/sql-database/sql-database-firewall-configure) prevents external applications and tools from connecting to the server or any database on the server unless a firewall rule is created to open the firewall for the specific IP address. When creating the new server above, the **Allow azure services to access server** box was checked, which allows any services using an Azure IP address to access this server and databases, so there is no need to create a specific firewall rule for this hands-on lab. To access the SQL server from an on-premises computer or application, you need to [create a server level firewall rule](https://docs.microsoft.com/azure/sql-database/sql-database-get-started-portal#create-a-server-level-firewall-rule) to allow the specific IP addresses to access the server.

### Task 9: Register the Microsoft DataMigration resource provider

In this task, you will register the Microsoft.DataMigration resource provider with your subscription in Azure.

1. In the [Azure portal](https://portal.azure.com), select **All services** from the Azure navigation pane, and then select **Subscriptions**.

    ![All services is highlighted in the Azure navigation pane, and Subscriptions is highlighted in the All services blade.](media/azure-portal-all-services-subscriptions.png "Azure All services blade")

2. Select the subscription you are using for this hands-on lab from the list, select **Resource providers**, enter "migration" into the filter box, and then select **Register** next to **Microsoft.DataMigration**.

    ![The Subscription blade is displayed, with Resource providers selected and highlighted under Settings. On the Resource providers blade, migration is entered into the filter box, and Register is highlighted next to Microsoft.DataMigration.](media/azure-portal-subscriptions-resource-providers-register-microsoft-datamigration.png "Resource provider registration")

### Task 10: Create Azure Database Migration Service

In this task, you will provision an instance of the Azure Database Migration Service (DMS).

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "database migration" into the Search the Marketplace box, select **Azure Database Migration Service** from the results, and select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "database migration" is entered into the Search the Marketplace box. Azure Database Migration Service is selected in the results.](media/create-resource-azure-database-migration-service.png "Create Azure Database Migration Service")

2. On the Create Migration Service blade, enter the following:

    - **Service Name**: Enter wwi-dms.

    - **Subscription**: Select the same subscription you are using for this hands-on lab.

        >**Note**:  If you see the message `Your subscription doesn't have proper access to Microsoft.DataMigration`, refresh the browser window before proceeding. If the message persists, verify you successfully registered the resource provider, and then you can safely ignore this message.

    - **Resource Group**: Select the hands-on-lab-SUFFIX resource group.

    - **Location**: Select the location you are using for resources in this hands-on lab.

    - **Virtual network**: Create a new virtual network by entering **wwi-dms-vnet** into the Virtual network name field and then select **OK**.

    - **Pricing tier**: Select Standard: 1 vCores.

        ![The Create Migration Service blade is displayed, with the values specified above entered into the appropriate fields.](media/create-migration-service.png "Create Migration Service")

3. Select **Create**.

4. It can take 15 minutes to deploy the Azure Data Migration Service.

You should follow all steps provided *before* performing the Hands-on lab.