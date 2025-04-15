# Product Backlog (MVP) - Assignement Management Web Application

## EPIC: Assignement Management Core

### User Story: Create Assignement
**As a** user,  
**I want to** create a new Assignement with all necessary fields,  
**So that** I can plan work in a structured and trackable way.

**Acceptance Criteria:**
1. Assignement Type (from Admin-defined list)
2. Auto-generated Assignement ID (unique)
3. Optional Parent Assignement ID (for subAssignements)
4. Mandatory: Description, Start Date, End Date
5. Complexity Level using Story Points (e.g., 1, 2, 3, 5, 8, 13...)
6. Default Status: "Not Started"
7. Validations:
   - End Date > Start Date
   - Child Assignement dates must be within parent Assignement dates (if applicable)
   - Parent and child Assignement types can differ
   - Circular dependencies must not be allowed
8. Assignement name can be duplicated
9. Cannot set Assignement as "Completed" if it has incomplete dependencies

---

### User Story: Assign Assignement
**As a** Assignement creator or admin,  
**I want to** assign a Assignement to a user or user group,  
**So that** responsibility is clearly defined.

**Acceptance Criteria:**
1. Only Assignement creator or Admin can assign/reassign
2. Assignement can be assigned to one user or one group
3. If assigned to a group:
   - Any member can claim the Assignement
   - Once claimed, it's locked to that user
4. Notifications:
   - On assignment: notify the assignee or all group members
   - On Assignement update: notify assignee and Assignement creator
   - Admin can enable/disable notification types globally
5. Reassignment allowed at any time by authorized users
6. All assignment and status updates are logged in the activity history
7. The creator or Admin is considered the Assignement owner

---

## EPIC: Assignement Update & Comments

### User Story: Update Assignement
**As a** Assignement owner or Admin,  
**I want to** update Assignement fields,  
**So that** the Assignement stays accurate and reflects changes.

**Acceptance Criteria:**
1. Editable fields: Description, Start/End Dates, Complexity, Assignement Type, Status
2. Cannot change Assignement ID
3. Updates logged in activity history
4. Respect constraints:
   - Cannot mark as "Completed" unless dependencies are done
   - Dates must remain valid in parent-child relationships

---

### User Story: Add Comments
**As a** user with Assignement access,  
**I want to** add comments to a Assignement,  
**So that** I can communicate updates or questions.

**Acceptance Criteria:**
1. Any user assigned to or owning a Assignement can add comments
2. Comments show timestamp and author
3. Comments are read-only once posted

---

## EPIC: Assignement Filtering & Viewing

### User Story: View and Filter Assignements
**As a** user,  
**I want to** view all Assignements with filters and search,  
**So that** I can easily manage and track my responsibilities.

**Acceptance Criteria:**
1. List view of Assignements with sorting and filtering by:
   - Status, Complexity, Start/End Date, Keyword
2. Search by keyword in Assignement name or description
3. Display: Assignement Name, Status, Assigned To, Start Date, End Date

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
**So that** I can assign Assignements at the group level.

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
   - Assignement assignment
   - Assignement updates
2. Optional: SMS support for notifications (future enhancement)

---

## EPIC: Authentication

### User Story: User Authentication
**As a** user,  
**I want to** log in securely,  
**So that** I can access my Assignements.

**Acceptance Criteria:**
1. Login with email + password
2. Google SSO login option
3. Password reset functionality