�
kC:\Projects\TodoCors\src\Todo.FluentMigrations\DbMigrations\Migrations\_20210926123601_Create_User_Table.cs
	namespace 	
Todo
 
. 
FluentMigrations 
.  
DbMigrations  ,
., -

Migrations- 7
{ 
[ 
	Migration 
( 
$num 
) 
] 
public 

class -
!_20210926123601_Create_User_Table 2
:3 4
	Migration5 >
{ 
public 
override 
void 
Down !
(! "
)" #
{$ %
}& '
public

 
override

 
void

 
Up

 
(

  
)

  !
{ 	
Create 
. 
Table 
( 
$str 
)  
. 

WithColumn 
( 
$str  
)  !
.! "
AsString" *
(* +
$num+ -
)- .
.. /

PrimaryKey/ 9
(9 :
): ;
. 

WithColumn 
( 
$str '
)' (
.( )
AsString) 1
(1 2
$num2 4
)4 5
.5 6
Nullable6 >
(> ?
)? @
. 

WithColumn 
( 
$str &
)& '
.' (
AsString( 0
(0 1
$num1 3
)3 4
.4 5
Nullable5 =
(= >
)> ?
. 

WithColumn 
( 
$str &
)& '
.' (
AsString( 0
(0 1
$num1 3
)3 4
.4 5
Nullable5 =
(= >
)> ?
. 

WithColumn 
( 
$str &
)& '
.' (
AsString( 0
(0 1
$num1 3
)3 4
.4 5
Nullable5 =
(= >
)> ?
. 

WithColumn 
( 
$str %
)% &
.& '
AsString' /
(/ 0
$num0 3
)3 4
.4 5
Nullable5 =
(= >
)> ?
;? @
} 	
} 
} �
TC:\Projects\TodoCors\src\Todo.FluentMigrations\DbMigrations\TableVersionMigration.cs
	namespace 	
Todo
 
. 
FluentMigrations 
.  
DbMigrations  ,
{ 
[  
VersionTableMetaData 
] 
public 

class !
TableVersionMigration &
:' (!
IVersionTableMetaData) >
{ 
public 
object 
ApplicationContext (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public

 
bool

 

OwnsSchema

 
=>

 !
true

" &
;

& '
public 
string 

SchemaName  
=>! #
$str$ &
;& '
public 
string 
	TableName 
=>  "
$str# 0
;0 1
public 
string 

ColumnName  
=>! #
$str$ -
;- .
public 
string !
DescriptionColumnName +
=>, .
$str/ <
;< =
public 
string 
UniqueIndexName %
=>& (
$str) :
;: ;
public 
string 
AppliedOnColumnName )
=>* ,
$str- 8
;8 9
} 
} 