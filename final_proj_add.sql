SELECT * FROM Teacher;
SELECT * FROM Student;
SELECT * FROM Class;
SELECT * FROM teaches_class;
SELECT * FROM Submission;
SELECT * FROM enrolled_in;
SELECT * FROM Assignment;
SELECT * FROM Announcement;
SELECT * FROM Material;
SELECT * FROM AsComment;
SELECT * FROM AComment;
SELECT * FROM MComment;
use fp

Create Procedure unenroll @s_id int,@c_code varchar(60)
As
Begin
Declare @id int
Select @id=class_id from class where Class_code=@c_code
Delete from enrolled_in Where student_id=@s_id and class_id=@id
End
Create procedure getAssignments @code varchar(30)
AS
Begin
Select * From Assignment Where class_id In (Select class_id from class where Class_code=@code) 
End
Create function getTeachername (@T_id int)
returns varchar(60)
Begin
DECLARE @t_name varchar(60)
Select @t_name=name from Teacher Where t_id=@T_id
return @t_name
End
CREATE FUNCTION CheckAssignmentNumberExists
(
    @assignmentNumber INT
)
RETURNS BIT
AS
BEGIN
    DECLARE @exists BIT;

    IF EXISTS(SELECT 1 FROM Assignment WHERE assignment_number = @assignmentNumber)
        SET @exists = 1; -- Assignment number exists
    ELSE
        SET @exists = 0; -- Assignment number does not exist

    RETURN @exists;
END;


select dbo.CheckAssignmentNumberExists(10) as exists_;

Create view Assignmentview
As
Select s.Student_id,s.sub_time As sub_time,s.A_id,s.attachment AS submission,a.assignment_text As question,s.marks,ss.name,a.marks As total_marks,a.Deadline from Submission s Join Student ss on s.Student_id=ss.S_id Join Assignment a ON s.A_id=a.id 

