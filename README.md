# API ECommerce

  Elaborar o banco de dados e através do método Scaffold criar o código inicial,
assim já teremos as pastas Model com as classes(tabelas do banco de dados) e a pasta Context(representação do banco de dados).

## Passo-a-passo

### 1.
  Com o projeto iniciado, criar mais três pastas: Interfaces, Repositories e Controllers. Partindo então da interface, criar uma interface que contém todos os métodos necessarios do CRUD.
### 2.
  Então criar o repositorio corresponde aquela interface, injetar a dependêcia do contexto e também cumprir o contrato da interface de criar todos os métodos dela no repositório,
elaborar a lógica dos métodos aqui.
### 3.
  Adicionar o serviço do repositório e também do contexto na classe Program. E por fim no Controller injetar o contexto do banco de dados atraves do construtor e aplicar os métodos do repositório usando os verbos HTTP (GET, PUT, POST, DELETE).






