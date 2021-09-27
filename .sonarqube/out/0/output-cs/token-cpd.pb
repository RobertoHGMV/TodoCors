Ì
9C:\Projects\TodoCors\src\Todo.Common\Commands\ICommand.cs
	namespace 	
Todo
 
. 
Common 
. 
Commands 
{ 
public 

	interface 
ICommand 
: 
IValidatable  ,
{ 
} 
} ¯
?C:\Projects\TodoCors\src\Todo.Common\Commands\ICommandResult.cs
	namespace 	
Todo
 
. 
Common 
. 
Commands 
{ 
public 

	interface 
ICommandResult #
{ 
} 
} è
9C:\Projects\TodoCors\src\Todo.Common\ConnectionOptions.cs
	namespace 	
Todo
 
. 
Common 
{ 
public 

class 
ConnectionOptions "
{ 
private 
static 
ConnectionOptions (
	_instance) 2
;2 3
public 
struct 

FieldsName  
{ 	
public		 
static		 
readonly		 "
string		# )
ConnPostgres		* 6
=		7 8
$str		9 G
;		G H
}

 	
	protected 
ConnectionOptions #
(# $
)$ %
{& '
}( )
public 
ConnectionOptions  
(  !
string! '
connStr( /
)/ 0
{ 	
GetInstance 
( 
) 
. 
ConnPostgres &
=' (
connStr) 0
;0 1
} 	
public 
string 
ConnPostgres "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
static 
ConnectionOptions '
GetInstance( 3
(3 4
)4 5
{ 	
if 
( 
	_instance 
is 
null !
)! "
	_instance 
= 
new 
ConnectionOptions  1
(1 2
)2 3
;3 4
return 
	_instance 
; 
} 	
} 
} ˜
9C:\Projects\TodoCors\src\Todo.Common\Handlers\IHandler.cs
	namespace 	
Todo
 
. 
Common 
. 
Handlers 
{ 
public 

	interface 
IHandler 
< 
T 
>  
where! &
T' (
:) *
ICommand+ 3
{ 
ICommandResult 
Handle 
( 
T 
command  '
)' (
;( )
} 
}		 Š
BC:\Projects\TodoCors\src\Todo.Common\Notifications\IValidatable.cs
	namespace 	
Todo
 
. 
Common 
. 
Notifications #
{ 
public 

	interface 
IValidatable !
{ 
void 
Validate 
( 
) 
; 
} 
} ½7
@C:\Projects\TodoCors\src\Todo.Common\Notifications\Notifiable.cs
	namespace 	
Todo
 
. 
Common 
. 
Notifications #
{ 
public 

class 

Notifiable 
: 
NotificationContext 1
{ 
public 

Notifiable 
IsNullOrEmpty '
(' (
string( .
val/ 2
,2 3
string4 :
property; C
,C D
stringE K
messageL S
)S T
{		 	
if

 
(

 
string

 
.

 
IsNullOrEmpty

 $
(

$ %
val

% (
)

( )
)

) *
AddNotification 
(  
property  (
,( )
message* 1
)1 2
;2 3
return 
this 
; 
} 	
public 

Notifiable 
	HasMinLen #
(# $
string$ *
val+ .
,. /
int0 3
min4 7
,7 8
string9 ?
property@ H
,H I
stringJ P
messageQ X
)X Y
{ 	
if 
( 
( 
val 
?? 
$str 
) 
. 
Length "
<# $
min% (
)( )
AddNotification 
(  
property  (
,( )
message* 1
)1 2
;2 3
return 
this 
; 
} 	
public 

Notifiable 
	HasMaxLen #
(# $
string$ *
val+ .
,. /
int0 3
max4 7
,7 8
string9 ?
property@ H
,H I
stringJ P
messageQ X
)X Y
{ 	
if 
( 
( 
val 
?? 
$str 
) 
. 
Length "
># $
max% (
)( )
AddNotification 
(  
property  (
,( )
message* 1
)1 2
;2 3
return 
this 
; 
} 	
public   

Notifiable   
IsInvalidValidDate   ,
(  , -
DateTime  - 5
val  6 9
,  9 :
string  ; A
property  B J
,  J K
string  L R
message  S Z
)  Z [
{!! 	
if"" 
("" 
val"" 
=="" 
DateTime"" 
.""  
MinValue""  (
||"") +
val"", /
==""0 2
DateTime""3 ;
.""; <
MaxValue""< D
)""D E
AddNotification## 
(##  
property##  (
,##( )
message##* 1
)##1 2
;##2 3
return%% 
this%% 
;%% 
}&& 	
public(( 

Notifiable(( 
	AreEquals(( #
(((# $
int(($ '
val((( +
,((+ ,
int((- 0
comparer((1 9
,((9 :
string((; A
property((B J
,((J K
string((L R
message((S Z
)((Z [
{)) 	
if** 
(** 
val** 
==** 
comparer** 
)**  
AddNotification++ 
(++  
property++  (
,++( )
message++* 1
)++1 2
;++2 3
return-- 
this-- 
;-- 
}.. 	
public00 

Notifiable00 
	AreEquals00 #
(00# $
object00$ *
val00+ .
,00. /
object000 6
comparer007 ?
,00? @
string00A G
property00H P
,00P Q
string00R X
message00Y `
)00` a
{11 	
if22 
(22 
val22 
.22 
Equals22 
(22 
comparer22 #
)22# $
)22$ %
AddNotification33 
(33  
property33  (
,33( )
message33* 1
)331 2
;332 3
return55 
this55 
;55 
}66 	
public88 

Notifiable88 
AreNotEquals88 &
(88& '
int88' *
val88+ .
,88. /
int880 3
comparer884 <
,88< =
string88> D
property88E M
,88M N
string88O U
message88V ]
)88] ^
{99 	
if:: 
(:: 
val:: 
!=:: 
comparer:: 
)::  
AddNotification;; 
(;;  
property;;  (
,;;( )
message;;* 1
);;1 2
;;;2 3
return== 
this== 
;== 
}>> 	
public@@ 

Notifiable@@ 
AreNotEquals@@ &
(@@& '
object@@' -
val@@. 1
,@@1 2
object@@3 9
comparer@@: B
,@@B C
string@@D J
property@@K S
,@@S T
string@@U [
message@@\ c
)@@c d
{AA 	
ifBB 
(BB 
!BB 
valBB 
.BB 
EqualsBB 
(BB 
comparerBB $
)BB$ %
)BB% &
AddNotificationCC 
(CC  
propertyCC  (
,CC( )
messageCC* 1
)CC1 2
;CC2 3
returnEE 
thisEE 
;EE 
}FF 	
publicHH 

NotifiableHH 
	IsGreaterHH #
(HH# $
decimalHH$ +
valHH, /
,HH/ 0
intHH1 4
comparerHH5 =
,HH= >
stringHH? E
propertyHHF N
,HHN O
stringHHP V
messageHHW ^
)HH^ _
{II 	
ifJJ 
(JJ 
(JJ 
doubleJJ 
)JJ 
valJJ 
>JJ 
comparerJJ &
)JJ& '
AddNotificationKK 
(KK  
propertyKK  (
,KK( )
messageKK* 1
)KK1 2
;KK2 3
returnMM 
thisMM 
;MM 
}NN 	
publicPP 

NotifiablePP 
IsInvalidEmailPP (
(PP( )
stringPP) /
valPP0 3
,PP3 4
stringPP5 ;
propertyPP< D
,PPD E
stringPPF L
msgErrorPPM U
)PPU V
{QQ 	
ifRR 
(RR 
!RR 
RegexRR 
.RR 
IsMatchRR 
(RR 
valRR "
,RR" #
$str	SS  
,
SS  ¡
RegexOptionsTT 
.TT 

IgnoreCaseTT '
)TT' (
)TT( )
AddNotificationUU 
(UU  
propertyUU  (
,UU( )
msgErrorUU* 2
)UU2 3
;UU3 4
returnWW 
thisWW 
;WW 
}XX 	
}YY 
}ZZ ò
BC:\Projects\TodoCors\src\Todo.Common\Notifications\Notification.cs
	namespace 	
Todo
 
. 
Common 
. 
Notifications #
{ 
public 

class 
Notification 
{ 
public 
string 
Key 
{ 
get 
;  
}! "
public 
string 
Message 
{ 
get  #
;# $
}% &
public 
Notification 
( 
string "
key# &
,& '
string( .
message/ 6
)6 7
{		 	
Key

 
=

 
key

 
;

 
Message 
= 
message 
; 
} 	
} 
} Ý
IC:\Projects\TodoCors\src\Todo.Common\Notifications\NotificationContext.cs
	namespace 	
Todo
 
. 
Common 
. 
Notifications #
{ 
public 

class 
NotificationContext $
{ 
private 
readonly 
List 
< 
Notification *
>* +
_notifications, :
;: ;
public		 
IReadOnlyCollection		 "
<		" #
Notification		# /
>		/ 0
Notifications		1 >
=>		? A
_notifications		B P
;		P Q
public

 
bool

 
HasNotifications

 $
=>

% '
_notifications

( 6
.

6 7
Any

7 :
(

: ;
)

; <
;

< =
public 
NotificationContext "
(" #
)# $
{ 	
_notifications 
= 
new  
List! %
<% &
Notification& 2
>2 3
(3 4
)4 5
;5 6
} 	
public 
void 
AddNotification #
(# $
string$ *
key+ .
,. /
string0 6
message7 >
)> ?
{ 	
_notifications 
. 
Add 
( 
new "
Notification# /
(/ 0
key0 3
,3 4
message5 <
)< =
)= >
;> ?
} 	
public 
void 
AddNotification #
(# $
Notification$ 0
notification1 =
)= >
{ 	
_notifications 
. 
Add 
( 
notification +
)+ ,
;, -
} 	
public 
void 
AddNotifications $
($ %
IReadOnlyCollection% 8
<8 9
Notification9 E
>E F
notificationsG T
)T U
{ 	
_notifications 
. 
AddRange #
(# $
notifications$ 1
)1 2
;2 3
} 	
public   
void   
AddNotifications   $
(  $ %
IList  % *
<  * +
Notification  + 7
>  7 8
notifications  9 F
)  F G
{!! 	
_notifications"" 
."" 
AddRange"" #
(""# $
notifications""$ 1
)""1 2
;""2 3
}## 	
public%% 
void%% 
AddNotifications%% $
(%%$ %
ICollection%%% 0
<%%0 1
Notification%%1 =
>%%= >
notifications%%? L
)%%L M
{&& 	
_notifications'' 
.'' 
AddRange'' #
(''# $
notifications''$ 1
)''1 2
;''2 3
}(( 	
})) 
}** 