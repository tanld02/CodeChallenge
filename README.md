# Backend Developer Code Challenge

This is a code challenge, which is intended to give RWE Solution Engineers a clear picture as to how you solve problems.

The tasks outlined in the code challenge are written in a style similar to User Stories, which may be found in a project.

It is okay if you are unable to complete the entire code challenge in the requested time-frame, go as far as you can and note where you stopped prior to submission.

For submission, please commit your code to a a git repository and provide a link to the interviewing Solution Engineer for review.

Additionally, this code-challenge is not intended to determine how much of a given programming language you have committed to memory, feel free to use any web-based resources or documentation to guide you.

Boilerplate has been created for you, however the organization and design of your solution will be entirely up to you.

No robustness or validation expected.

Database script with sample data is included in dbscript.sql file, boilerplate uses local DB, can be swapped for containerized or other solution. Data structure is as follows:

Movie:
	- Title
	- Director
	- Release Date
	- Rating (0-10)

Director:
	- Name
	- Birthdate
	- Movies


## Task 1 Add CRUD API Endpoint

As a user, I would like the ability to create, retrieve, update and delete Directors and Movies. There is a relationship which binds movies to directors.

### Acceptance Criteria:

1. Data Models created
2. CRUD enpoints written:
	a. get specific movie by id
	b. get all movies by director
	c. edit specific movie
	d. delete specific movie
	e. get specific director by id
	f. get all directors
	g. create a director
	h. edit specific director
	i. delete specific director
	j. (bonus) create a movie
3. Controllers and controller units of work pre-process inputs if applicable
4. Database units of work interface with MSSQL database using Entity Framework to create, retrieve, store or remove data
