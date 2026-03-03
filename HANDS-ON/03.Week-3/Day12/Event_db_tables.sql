--Create Database 
CREATE DATABASE EventDb

USE EventDb

 -- Create table (1 UserInfo)
 CREATE TABLE UserInfo
(
	EmailId VARCHAR(100) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL,
	[Role] VARCHAR(50) NOT NULL CHECK (Role IN ('Admin','Participant')),
	[Password] VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

--Inserting sample records 

INSERT INTO UserInfo VALUES ('admin1@example.com', 'RamaAdmin', 'Admin', 'Admin123');
INSERT INTO UserInfo VALUES('user1@example.com', 'JohnDoe', 'Participant', 'User1234');
INSERT INTO UserInfo VALUES('user2@example.com', 'AnitaP', 'Participant', 'Pass7890');
INSERT INTO UserInfo VALUES ('admin2@example.com', 'SuperAdmin', 'Admin', 'Secure99');
INSERT INTO UserInfo VALUES ('user3@example.com', 'DavidK', 'Participant', 'MyPass12');



--Create table (2 EventDetails)
CREATE TABLE EventDetails(
EventId INT PRIMARY KEY,
EventName VARCHAR(50) NOT NULL,
EventCategory VARCHAR(50) NOT NULL,
EventDate DATETIME NOT NULL,
Description varchar(250),
Status varchar(50) CHECK( Status IN ('Active','In-Active'))
);

--Inserting sample records
INSERT INTO EventDetails 
VALUES (1, 'Tech Conference 2026', 'Technology', '2026-04-15 10:00:00',
        'Annual technology conference focusing on AI and Cloud computing.',
        'Active');

INSERT INTO EventDetails 
VALUES (2, 'Inter-College Football', 'Sports', '2026-05-20 15:30:00',
        'Regional inter-college football tournament.',
        'Active');

INSERT INTO EventDetails 
VALUES (3, 'Cultural Fest', 'Cultural', '2026-06-10 09:00:00',
        'Music, dance, and art performances by students.',
        'In-Active');

INSERT INTO EventDetails 
VALUES (4, 'Startup Pitch Day', 'Business', '2026-07-05 11:00:00',
        'Entrepreneurs pitch ideas to investors and mentors.',
        'Active');


-- Creating table(3 SpeakersDetails)
CREATE TABLE SpeakersDetails(
SpeakerId INT PRIMARY KEY,
SpeakerName VARCHAR(50) NOT NULL
);

--Inserting sample records
INSERT INTO SpeakersDetails 
VALUES (1, 'Dr. Anil Kumar');

INSERT INTO SpeakersDetails 
VALUES (2, 'Priya Sharma');

INSERT INTO SpeakersDetails 
VALUES (3, 'Rahul Mehta');

INSERT INTO SpeakersDetails 
VALUES (4, 'Sneha Reddy');



--create table (4 SessionInfo)
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL 
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(250),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(200),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId),
   
);

--Inserting sample records
INSERT INTO SessionInfo 
VALUES (1, 1, 'AI Trends 2026', 1,
        'Overview of upcoming AI technologies.',
        '2026-04-15 10:00:00',
        '2026-04-15 11:00:00',
        'https://example.com/ai-session');

INSERT INTO SessionInfo 
VALUES (2, 1, 'Cloud Architecture', 2,
        'Designing scalable cloud systems.',
        '2026-04-15 11:30:00',
        '2026-04-15 12:30:00',
        'https://example.com/cloud-session');

INSERT INTO SessionInfo 
VALUES (3, 2, 'Winning Strategies', 3,
        NULL,
        '2026-05-20 16:00:00',
        '2026-05-20 17:00:00',
        'https://example.com/football-session');

INSERT INTO SessionInfo 
VALUES (4, 3, 'Modern Dance Forms', 4,
        'Exploring contemporary dance styles.',
        '2026-06-10 09:00:00',
        '2026-06-10 10:00:00',
        NULL);


--Create table(5 ParticipantEventDetails)
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL CHECK(IsAttended IN(0,1)),
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);


--Inserting sample records
INSERT INTO ParticipantEventDetails 
VALUES (1, 'user1@example.com', 1, 1, 1);

INSERT INTO ParticipantEventDetails 
VALUES (2, 'user2@example.com', 1, 2, 0);

INSERT INTO ParticipantEventDetails 
VALUES (3, 'user3@example.com', 2, 3, 1);

INSERT INTO ParticipantEventDetails 
VALUES (4, 'user1@example.com', 3, 4, 0);