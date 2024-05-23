# TravelAgency
TravelAgency é uma aplicação back-end desenvolvida em .NET 8 para gerenciar uma agência de viagens. Esta API garante o funcionamento de reservas e a gestão de pacotes utilizando os princípios do Domain Driven Design (DDD).
<br/><br/><br/>
**Funcionalidades**
- Gerenciamento de clientes
- Gerenciamento de destinos
-	Gerenciamento de pacotes de viagem
-	Criação e consulta de reservas
-	Processamento de pagamentos

<br>

**Tecnologias Utilizadas**
-	.NET 8
-	Entity Framework Core
-	MySQL
-	Swagger para documentação de API

<br>

**Endpoints**

Clientes
-	GET /api/clientes: Retorna todos os clientes.
-	GET /api/clientes/{id}: Retorna um cliente específico.
-	POST /api/clientes: Cria um novo cliente.
-	PUT /api/clientes/{id}: Atualiza um cliente existente.
-	DELETE /api/clientes/{id}: Deleta um cliente.

Destinos
-	GET /api/destinos: Retorna todos os destinos.
-	GET /api/destinos/{id}: Retorna um destino específico.
-	POST /api/destinos: Cria um novo destino.
-	PUT /api/destinos/{id}: Atualiza um destino existente.
-	DELETE /api/destinos/{id}: Deleta um destino.

Pacotes
-	GET /api/pacotes: Retorna todos os pacotes de viagem.
-	GET /api/pacotes/{id}: Retorna um pacote de viagem específico.
-	POST /api/pacotes: Cria um novo pacote de viagem.
-	PUT /api/pacotes/{id}: Atualiza um pacote de viagem existente.
-	DELETE /api/pacotes/{id}: Deleta um pacote de viagem.

Reservas
-	GET /api/reservas: Retorna todas as reservas.
-	GET /api/reservas/{id}: Retorna uma reserva específica.
-	POST /api/reservas: Cria uma nova reserva.
-	PUT /api/reservas/{id}: Atualiza uma reserva existente.
-	DELETE /api/reservas/{id}: Deleta uma reserva.

Pagamentos
-	GET /api/pagamentos: Retorna todos os pagamentos.
-	GET /api/pagamentos/{id}: Retorna um pagamento específico.
-	POST /api/pagamentos: Cria um novo pagamento.
-	PUT /api/pagamentos/{id}: Atualiza um pagamento existente.
-	DELETE /api/pagamentos/{id}: Deleta um pagamento.



