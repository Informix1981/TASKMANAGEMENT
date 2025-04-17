# Product Backlog (MVP) - Assignment Management Web Application

## EPIC: Assignment Management Core

### User Story: Create Assignment
**As a** user,  
**I want to** create a new Assignment with all necessary fields,  
**So that** I can plan work in a structured and trackable way.

**Acceptance Criteria:**
1. Assignment Type (from Admin-defined list)
2. Auto-generated Assignment ID (unique)
3. Optional Parent Assignment ID (for subAssignments)
4. Mandatory: Description, Start Date, End Date
5. Complexity Level using Story Points (e.g., 1, 2, 3, 5, 8, 13...)
6. Default Status: "Not Started"
7. Validations:
   - End Date > Start Date
   - Child Assignment dates must be within parent Assignment dates (if applicable)
   - Parent and child Assignment types can differ
   - Circular dependencies must not be allowed
8. Assignment name can be duplicated
9. Cannot set Assignment as "Completed" if it has incomplete dependencies

---

### User Story: Assign Assignment
**As a** Assignment creator or admin,  
**I want to** assign a Assignment to a user or user group,  
**So that** responsibility is clearly defined.

**Acceptance Criteria:**
1. Only Assignment creator or Admin can assign/reassign
2. Assignment can be assigned to one user or one group
3. If assigned to a group:
   - Any member can claim the Assignment
   - Once claimed, it's locked to that user
4. Notifications:
   - On assignment: notify the assignee or all group members
   - On Assignment update: notify assignee and Assignment creator
   - Admin can enable/disable notification types globally
5. Reassignment allowed at any time by authorized users
6. All assignment and status updates are logged in the activity history
7. The creator or Admin is considered the Assignment owner

---

## EPIC: Assignment Update & Comments

### User Story: Update Assignment
**As a** Assignment owner or Admin,  
**I want to** update Assignment fields,  
**So that** the Assignment stays accurate and reflects changes.

**Acceptance Criteria:**
1. Editable fields: Description, Start/End Dates, Complexity, Assignment Type, Status
2. Cannot change Assignment ID
3. Updates logged in activity history
4. Respect constraints:
   - Cannot mark as "Completed" unless dependencies are done
   - Dates must remain valid in parent-child relationships

---

### User Story: Add Comments
**As a** user with Assignment access,  
**I want to** add comments to a Assignment,  
**So that** I can communicate updates or questions.

**Acceptance Criteria:**
1. Any user assigned to or owning a Assignment can add comments
2. Comments show timestamp and author
3. Comments are read-only once posted

---

## EPIC: Assignment Filtering & Viewing

### User Story: View and Filter Assignments
**As a** user,  
**I want to** view all Assignments with filters and search,  
**So that** I can easily manage and track my responsibilities.

**Acceptance Criteria:**
1. List view of Assignments with sorting and filtering by:
   - Status, Complexity, Start/End Date, Keyword
2. Search by keyword in Assignment name or description
3. Display: Assignment Name, Status, Assigned To, Start Date, End Date

---

## EPIC: User & Group Management

### User Story: Create & Manage Users
**As an** admin,  
**I want to** create, update, or delete users,  
**So that** the right people have system access.

**Acceptance Criteria:**
1. Create user with Email, Name, and Role (User/Admin)
2. Update/delete existing users

---

### User Story: Manage User Groups
**As an** admin,  
**I want to** manage user groups,  
**So that** I can assign Assignments at the group level.

**Acceptance Criteria:**
1. Create user groups
2. Assign users to/from groups

---

## EPIC: Notifications

### User Story: Configure Notifications
**As an** admin,  
**I want to** enable or disable notification types,  
**So that** I can manage communication settings.

**Acceptance Criteria:**
1. Toggle email notifications for:
   - Assignment assignment
   - Assignment updates
2. Optional: SMS support for notifications (future enhancement)

---

## EPIC: Authentication

### User Story: User Authentication
**As a** user,  
**I want to** log in securely,  
**So that** I can access my Assignments.

**Acceptance Criteria:**
1. Login with email + password
2. Google SSO login option
3. Password reset functionality