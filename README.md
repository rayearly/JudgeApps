# JudgeApps
## Introduction
This is a prototype for Judging Web application using ASP.NET MVC5. Basically, this application is used by Jury to judge booth(s) that are assigned to them.

### Case 1
A Jury can be assigned to many booths and the will give marks to the booths they are assigned to.
Each booth may have many Jury, multiple jury will be judging for a booth. It is required to avoid any bias for that group.
**Conclusion:** Need to create Many-to-Many relationship between Judge and Booth.

### Case 2
A booth can be assigned to many groups. As a booth may be used multiple session as they may be a lot of groups that need to present. (eg; morning & evening session)
Each group is only presenting in one and only one booth.
**Conclusion:** Need to create One-To-Many relationship between Booth to Group

### Case 4
A Group can have many members (participant). A participant may join a group. But there are cases where a participant joining multiple group, but it doesn't really matter since the data can be kept multiple time (not a lot instance, so small matter).
**Conclusion:** Need to create One-to-Many relationship between Group to Participant.

### Case 5
Where should I place my Mark entity???

## Apps Entities
* Judge
* Booth
* Mark
* JudgeBoothMark - Junction table to store Id of Judge, Booth Mark
* Group
* Participant

## Functions (CRUD)
### Creation
* **Judge**
* **Booth** - May want to create ID automatically since No of booths is a lot.
* Seeds the **Group** and **Participant** table manually - since this may gotten from Registration Site Database.

### Template : [Purple Booth Template](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2)

