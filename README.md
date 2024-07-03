# TravelAgency
TravelAgency é uma aplicação back-end desenvolvida em .NET 8 para gerenciar uma agência de viagens. Esta API garante o funcionamento de reservas e a gestão de pacotes utilizando os princípios do Domain Driven Design (DDD).
<br/><br/><br/>
**Funcionalidades**
- Gerenciamento de usuarios
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

Users
-	GET /api/Users: Retorna todos os clientes.
-	GET /api/Users/{id}: Retorna um cliente específico.
-	POST /api/Users: Cria um novo cliente.
-	PUT /api/Users/{id}: Atualiza um cliente existente.
-	DELETE /api/Users/{id}: Deleta um cliente.

Uf
-	GET /api/Uf: Retorna todos os destinos.
-	GET /api/Uf/{id}: Retorna um destino específico.

Package
-	GET /api/Package: Retorna todos os pacotes de viagem.
-	GET /api/Package/{id}: Retorna um pacote de viagem específico.
-	POST /api/Package: Cria um novo pacote de viagem.
-	PUT /api/Package/{id}: Atualiza um pacote de viagem existente.
-	DELETE /api/Package/{id}: Deleta um pacote de viagem.

Booking
-	GET /api/Booking: Retorna todas as reservas.
-	GET /api/Booking/{id}: Retorna uma reserva específica.
-	POST /api/Booking: Cria uma nova reserva.
-	PUT /api/Booking/{id}: Atualiza uma reserva existente.
-	DELETE /api/Booking/{id}: Deleta uma reserva.

Payment
-	GET /api/payment: Retorna todos os pagamentos.
-	GET /api/payment/{id}: Retorna um pagamento específico.
-	GET /api/payment-methods: Retorna todos os métodos de pagamento.
-	POST /api/payment: Cria um novo pagamento.
-	PUT /api/payment/{id}: Atualiza um pagamento existente.
-	DELETE /api/payment/{id}: Deleta um pagamento.
  



