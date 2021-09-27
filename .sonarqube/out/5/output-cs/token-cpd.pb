Ø
GC:\Projects\TodoCors\src\Todo.DependencyInjection\DependencyResolver.cs
	namespace

 	
Todo


 
.

 
DependencyInjection

 "
{ 
public 

class 
DependencyResolver #
{ 
public 
void 
Resolver 
( 
IServiceCollection /
services0 8
)8 9
{ 	
services 
. 
AddDbContext !
<! "
TodoDataContext" 1
,1 2
TodoDataContext3 B
>B C
(C D
)D E
;E F
services 
. 
AddTransient !
<! "
IUow" &
,& '
Uow( +
>+ ,
(, -
)- .
;. /
services 
. 
AddTransient !
<! "
IUserRepository" 1
,1 2
UserRepository3 A
>A B
(B C
)C D
;D E
services 
. 
AddTransient !
<! "
UserHandler" -
,- .
UserHandler/ :
>: ;
(; <
)< =
;= >
services 
. 
AddTransient !
<! "!
IVersionTableMetaData" 7
,7 8!
TableVersionMigration9 N
>N O
(O P
)P Q
;Q R
} 	
} 
} 