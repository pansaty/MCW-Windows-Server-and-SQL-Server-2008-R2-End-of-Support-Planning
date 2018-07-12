![](images/HeaderPic.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Windows Server and SQL Server 2008/R2 End of Support Planning
</div>

<div class="MCWHeader2">
Whiteboard design session student guide
</div>

<div class="MCWHeader3">
July 2018
</div>


Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Windows Server 2008 and SQL Server 2008 End of Support Planning whiteboard design session student guide](#windows-server-2008-and-sql-server-2008-end-of-support-planning-whiteboard-design-session-student-guide)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Step 1: Review the customer case study](#step-1-review-the-customer-case-study)
        - [Customer situation](#customer-situation)
        - [Customer needs](#customer-needs)
        - [Customer objections](#customer-objections)
        - [Infographic for common scenarios](#infographic-for-common-scenarios)
    - [Step 2: Design a proof of concept solution](#step-2-design-a-proof-of-concept-solution)
    - [Step 3: Present the solution](#step-3-present-the-solution)
    - [Wrap-up](#wrap-up)
    - [Additional references](#additional-references)

<!-- /TOC -->


# Windows Server 2008 and SQL Server 2008 End of Support Planning whiteboard design session student guide

## Abstract and learning objectives

Many customers have huge on-premises footprints of Windows and SQL Server 2008 and 2008 R2, but these products are rapidly approaching End of Support. This whiteboard design session is designed to help customers understand the risks of running unsupported software, and presents great options for using EOS to modernize in Azure or on-premises.

Attendees will leave with the information they need to develop a solid migration plan to keep their mission-critical apps and data protected as they transition and modernize their application, data and infrastructure environment.

- How to get an inventory of your 2008 server environment
- How to categorize 2008 workloads, and evaluate the best option for each category
- Migration and upgrade tools available
- TCO analysis tools, plus great offers from Microsoft to leverage existing licenses
- Innovations of recent product updates, licensing and technologies


## Step 1: Review the customer case study 

**Outcome** 

Analyze your customer’s needs.
Time frame: 15 minutes 
Directions: With all participants in the session, the facilitator/SME presents an overview of the customer case study along with technical tips. 
1.  Meet your table participants and trainer 
2.  Read all of the directions for steps 1–3 in the student guide 
3.  As a table team, review the following customer case study


### Customer situation

Fabrikam is an automotive parts manufacturer based in the United States. They are an OEM manufacturer of parts for commercial vehicles. They have manufacturing plants throughout the US and Mexico. Fabrikam competes globally with other manufacturers for contracts, this highly competitive environment makes Fabrikam very price sensitive. 

"We are preparing for Windows and SQL Server 2008/R2 end of support and would like to better understand our options for upgrade and migration.", Sloane Peterson, Fabrikam CIO

Fabrikam does not have a complete company wide inventory of the number of servers and applications running on legacy software and many of the systems are undocumented and not well understood by IT staff. They want to understand their current workloads and they would like to take advantage of the cloud where appropriate.  

Fabrikam currently has many legacy applications that are running on Windows Server 2008 including a line of business inventory management system that also leverages SQL Server 2008. The inventory management system is considered a mission critical application. It is highly complex and is leveraged by various parts of the business with many upstream and downstream dependencies. Some of these dependencies are Linux systems. Because many of these systems are critical to the business they need to understand the business continuity and disaster recovery options when upgrading in place or migrating to the cloud.

The Inventory Management system is one of the most critical systems at Fabrikam. It was originally architected when the company was much smaller. It currently runs on Windows Server 2008 R2 with a separate SQL Server 2008 backend. The application team that supports it would ultimately like to rearchitect the system for better scalability and to take better advantage of new innovations in inventory tracking. They see cloud technologies as a good fit for this type of application but they lack the experience, expertise and time to rebuild the application right now.  

They would like a short term plan to maintain support of the system while the application team reskills and gains experience in Azure. 

They would also like a long term plan to take advantage of the new advancements in SQL Server while still getting the most out of their Azure investment by minimizing the administrative overhead.

"We would love to take advantage of the cloud to minimize the administrative overhead of the Inventory Management System, we simply cannot get all of the dependencies sorted out before the official end of support." Frances Bradley, Manager Inventory Applications

### Customer needs 

1.  Identify migration and upgrade tools to help in assessing, migrating and optimizing the current environment.

1.  Fabrikam needs to build an inventory of their current systems and provide some organization around the various systems they have in place. The inventory should include dependencies and tiering of the applications to help in prioritizing application upgrades and migrations.

1.  Fabrikam has a large mix of applications including Micrososft, third-party and custom applications. They need to evaluate the upgrade options for each workload.

1.  They would like to modernize applications and take advantage of the cloud where it makes sense. How should they go about identifying suitable applications and the costs of running them in Azure?

1.  Applications that are not moving to Azure will need to be optimized on premises.

### Customer objections 

1.  We have some 3rd party applications where we do not have complete control of the code or schema. We will not be able to upgrade these applications before the end of support. What options do we have for these applications?

1.  We have hundreds of applications that are running on servers that are nearing end of support. Some are virtual machines running on VMWare, some are older physical machines. Does Microsoft have any tools to help us identify these applications?

1.  "We need to minimize the amount of downtime during migration. How will we do this? What kind of downtime are we looking at?", Jude Watkins, Director of Database Operations

1.  When migrating workloads into Azure, how do we handle security and authentication? Will my workloads continue to use the same authentication that was used on-premises?

1.  Some of our data has very strict regulatory constraints and cannot leave the country of origin, how do we handle this type of data in Azure? Will my data be replicated or located in another country?

1.  How will migrating from SQL Server to Azure SQL Database impact the role of our database administration team?

### Infographic for common scenarios

**Azure Migrate**

![Azure Migrate allows easy discovery VMWare VMs and applications including service dependencies](images/2018-06-15-15-58-44.png)

**Azure Database Migration Service**

![The Azure Database Migration Service allows you to migrate from multiple database sources to Azure Data platforms with minimal downtime](images/2018-06-15-15-59-12.png)

**Azure Security Center**

![The Azure Security Center provides a unified view of security across on-premises and cloud workloads](images/2018-06-15-15-59-48.png)

**Cost Management for Azure**

![Azure Cost Management by Cloudyn allows you to monitor and visualize usage and cost to better optimize your cloud spend](images/2018-06-15-16-00-20.png)

## Step 2: Design a proof of concept solution

**Outcome** 
Design a solution and prepare to present the solution to the target customer audience in a 15-minute chalk-talk format. 

Time frame: 60 minutes

**Business needs**

Directions: With all participants at your table, answer the following questions and list the answers on a flip chart. 
1.  Who should you present this solution to? Who is your target customer audience? Who are the decision makers? 
2.  What customer business needs do you need to address with your solution?

**Design** 

Directions: With all participants at your table, respond to the following questions on a flip chart.

_Asses - Plan for end of support_

- **Inventory**: Fabrikam needs to build an inventory of their current systems. Determine what needs to be tracked in this inventory. What information would you track in your inventory to help Fabrikam organize and prioritize systems for their end of support planning? How would you prioritize systems?

- **Tools:** Identify any tools that Fabrikam might use to help with assesments, migrations and optimizations of their Windows Server and SQL Server systems. You should identify which stage of the process you would leverage these tools and what value they provide.

- **Cost Analysis:** Fabrikam currently has Software Assurance. Provide a cost analysis of the following options available to Fabrikam:

    a.  Maintain current version

    b.  Rehost - Migrate to cloud

_Migrate - Upgrade in place or migrate to Azure_

-  **Migration strategy:** Fabrikam would like to take full advantage of the cloud. They would like to create a multifaceted application strategy to determine how applications will be migrated to Azure. You need to identify the various paths to moving applications to the cloud and when each path provides the highest value.

-  **Windows Server Upgrades and Migrations**: Detailed migration steps:

    a.  How will physical machines be migrated to Azure?

    b.  How will machines hosted in VMWare be migrated to Azure?

    c. Some IIS based web sites will be migrated to Azure Web Apps. Document the requirements and the process for migrating to Azure Web Apps. 

-  **SQL Server Upgrades and Migrations**: Provide Fabrikam with detailed migration steps. At a minimum, your steps should cover the following scenarios:

    a.  How SQL Servers that will be migrated to Azure virtual machines be migrated?

    b.  How SQL databases that will be migrated to Azure SQL Database and Azure SQL Database Managed Instances be migrated? 

-  **Diagram the solution**

_Optimize_

-  **Security and Authentication:** - How will Active Directory be managed in the cloud? Will we continue to do things the way we have in the past?

-  **Cost management:** - With the ease of deploying and scaling services in the cloud we are concerned about cost management. What tools can we leverage to help us with cost management?

-  **Compliance:** - We want to make sure that our cloud resources are properly secured so that we can maintain compliance. How do we monitor security and maintain compliance in the cloud? What about systems that remain on premises?

-  **SQL Database Management:** - What type of database administration tasks can we automate in Azure SQL Database? We are looking to minimize the amount of administrative tasks our DBAs are doing and focus them on higher value tasks.

**Prepare**

Directions: With all participants at your table: 

1.  Identify any customer needs that are not addressed with the proposed solution. 
2.  Identify the benefits of your solution. 
3.  Determine how you will respond to the customer’s objections. 

Prepare a 15-minute chalk-talk style presentation to the customer. 


## Step 3: Present the solution

**Outcome**
 
Present a solution to the target customer audience in a 15-minute chalk-talk format.

Time frame: 30 minutes

**Presentation** 

Directions:
1.  Pair with another table.
2.  One table is the Microsoft team and the other table is the customer.
3.  The Microsoft team presents their proposed solution to the customer.
4.  The customer makes one of the objections from the list of objections.
5.  The Microsoft team responds to the objection.
6.  The customer team gives feedback to the Microsoft team. 
7.  Tables switch roles and repeat Steps 2–6.

##  Wrap-up 

Time frame: 15 minutes

-   Tables reconvene with the larger group to hear a SME share the preferred solution for the case study

##  Additional references
|    |            |
|----------|:-------------:|
| **Description** | **Links** |
| Azure Migration Center  | <https://azure.microsoft.com/en-us/migration/>  |
| Azure Hybrid Benefit  | <https://azure.microsoft.com/en-us/pricing/hybrid-benefit/>  |
| Azure Migrate  | <https://docs.microsoft.com/en-us/azure/migrate/migrate-overview>   |
| Azure TCO Calculator  | https://azure.microsoft.com/en-us/pricing/tco/calculator/  |
| Azure Site Recovery | <https://docs.microsoft.com/en-us/azure/site-recovery/>    |
| Database Migration Guide   | <https://datamigration.microsoft.com/>      |
| Azure Database Migration Service   | <https://docs.microsoft.com/en-us/azure/dms/dms-overview>      |
| Data Migration Assistant   | <https://docs.microsoft.com/en-us/sql/dma/dma-overview?view=sql-server-2017>      |
| Database Experimentation Assistant   | https://blogs.msdn.microsoft.com/datamigration/2017/07/25/dea-2-1-general-availability-release-overview-database-experimentation-assistant/      |
| Azure Cost Management   | <https://docs.microsoft.com/en-us/azure/cost-management/overview>   |