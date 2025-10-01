# 🛵 MotoMap

Este projeto foi desenvolvido como parte do desafio da faculdade, com o objetivo de criar uma **API REST** que representa digitalmente um pátio de motos da empresa **Mottu**, exibindo a localização e status de cada moto em tempo real, utilizando sensores RFID e tecnologias modernas de backend.

### Integrantes
- **Eduardo do Nascimento Barriviera - RM555309**
- **Thiago Lima de Freitas - RM556795**
- **Bruno centurion Fernandes - RM556531**
---

## 🚀 Funcionalidades

- Cadastro de motos com validações de negócio
- Atualização de posição e status em tempo real
- API RESTful com endpoints organizados
- Documentação Swagger integrada
- Acesso e persistência de dados em banco Oracle via EF Core

---

## 🏗 Estrutura da Aplicação

A aplicação segue uma arquitetura **em camadas**, garantindo manutenção e escalabilidade:

- **Domain:** Contém entidades e regras de negócio centrais
- **Application:** Camada de casos de uso e lógica de aplicação
- **Infrastructure:** Implementação de acesso a dados, integração com API e recursos externos
- **API:** Camada que expõe os endpoints REST consumidos pelo frontend

---

## 🛠️ Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- **ASP.NET Core Web API**
- **Entity Framework Core** + `Oracle.EntityFrameworkCore`
- **AutoMapper** para mapeamento entre entidades e DTOs
- **Swagger / Swashbuckle** para documentação da API
- **Oracle Database** como banco de dados relacional

---
## 📌 Exemplos dos Endpoints

### 1️⃣ Listar todas as motos
**GET** `http://localhost:5273/api/motos`

**Retorno esperado:** JSON com todas as motos

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "placa": "ABC1D23",
    "posicao": "A1",
    "status": "pronta",
    "ultimaAtualizacao": "2025-10-01T22:31:36.342Z"
  },
  {
    "id": "7b9c1234-1234-5678-9abc-1234567890ab",
    "placa": "XYZ9A87",
    "posicao": "B2",
    "status": "revisao",
    "ultimaAtualizacao": "2025-10-01T22:35:12.123Z"
  }
]
```
### 2️⃣ Cadastrar uma nova moto

**POST** `http://localhost:5273/api/motos/criar`

**Corpo da requisição (JSON)**:
```json
{
  "placa": "ABC1D23",
  "posicao": "A1",
  "status": "pronta",
  "ultimaAtualizacao": "2025-10-01T22:31:36.342Z"
}
```

**Retorno esperado:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "placa": "ABC1D23",
  "posicao": "A1",
  "status": "pronta",
  "ultimaAtualizacao": "2025-10-01T22:31:36.342Z"
}
```
### 3️⃣ Atualizar posição ou status de uma moto

**PUT** `http://localhost:5273/api/motos/editar/{id}`

**Corpo da requisição (JSON):**
```json
{
  "posicao": "B3",
  "status": "revisao"
}
```
**Retorno esperado:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "placa": "ABC1D23",
  "posicao": "B3",
  "status": "revisao",
  "ultimaAtualizacao": "2025-10-01T23:00:00.000Z"
}
```

### 4️⃣ Deletar uma moto

**DELETE** `http://localhost:5273/api/motos/deletar/{id}`

**Retorno esperado: 204**

---

## ⚙️ Como rodar o projeto

### ✅ Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Banco de dados Oracle acessível
- Visual Studio 2022 ou superior (recomendado)

---

### 📦 1. Clonar o repositório

```bash
git clone https://github.com/edu1805/Challange-Mottu-dotnet.git
cd Challange-Mottu-dotnet
```

---

### 🔧 2. Configurar o banco de dados Oracle
No arquivo appsettings.json, configure a sua string de conexão:
```bash
"ConnectionStrings": {
  "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=SEU_ID;Password=SUA_PASSWORD"
}
```

---

### 🧱 3. Gerar as Migrations (se necessário)
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Inicial --context Cp2Context
dotnet ef database update --context Cp2Context
```

---

### ▶️ 4. Executar a aplicação
```bash
dotnet run
```
Ou direto pelo Visual Studio com F5.

---

#### Acesse a documentação da API em:
```bash
https://localhost:port/swagger
```
