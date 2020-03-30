create table Funcionario(
	IdFuncionario		integer			identity(1,1),
	Nome				nvarchar(150)	not null,
	Salario				decimal(18,2)	not null,
	DataAdmissao		DateTime		not null,
	Cargo				nvarchar(150)	not null,
	primary key (IdFuncionario)

)