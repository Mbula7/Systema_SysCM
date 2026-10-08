using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_GMMunicipal.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provicias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provicias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposInfracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gravidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInfracoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provicias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provicias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Condutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroBI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCartaConducao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaCarta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmissaoCarta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidadeCarta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condutors_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "escolasCoducaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Licencas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLicenciamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escolasCoducaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_escolasCoducaos_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FiscalUtilizadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroIdentificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalUtilizadors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalUtilizadors_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motorizadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoFabrico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroChassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroMotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cilindrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeCarga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    condutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorizadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorizadas_Condutors_condutorId",
                        column: x => x.condutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    TipoReceita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMunicipio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorEscola = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receitas_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EscolaId = table.Column<int>(type: "int", nullable: true),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargaHoraria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cursos_escolasCoducaos_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "escolasCoducaos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Acidentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    MotorizadaId = table.Column<int>(type: "int", nullable: false),
                    TipoAcidente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gravidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroFeridos = table.Column<int>(type: "int", nullable: false),
                    NumeroMortos = table.Column<int>(type: "int", nullable: false),
                    NumeroVeiculos = table.Column<int>(type: "int", nullable: false),
                    CausaProvavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondicoesClimaticas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoVia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acidentes_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acidentes_Motorizadas_MotorizadaId",
                        column: x => x.MotorizadaId,
                        principalTable: "Motorizadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Infracaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    MotorizadaId = table.Column<int>(type: "int", nullable: false),
                    FiscalId = table.Column<int>(type: "int", nullable: false),
                    TipoInfracaoId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infracaos_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Infracaos_FiscalUtilizadors_FiscalId",
                        column: x => x.FiscalId,
                        principalTable: "FiscalUtilizadors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Infracaos_Motorizadas_MotorizadaId",
                        column: x => x.MotorizadaId,
                        principalTable: "Motorizadas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Infracaos_TiposInfracoes_TipoInfracaoId",
                        column: x => x.TipoInfracaoId,
                        principalTable: "TiposInfracoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inspencaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorizadaId = table.Column<int>(type: "int", nullable: false),
                    FiscalId = table.Column<int>(type: "int", nullable: false),
                    DataInspeccao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoMotorizada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Travões = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pneus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luzes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Espelhos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documentacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspencaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspencaos_FiscalUtilizadors_FiscalId",
                        column: x => x.FiscalId,
                        principalTable: "FiscalUtilizadors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspencaos_Motorizadas_MotorizadaId",
                        column: x => x.MotorizadaId,
                        principalTable: "Motorizadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLicenca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoLicenca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoCancelamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    MotorizadaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licencas_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Licencas_Motorizadas_MotorizadaId",
                        column: x => x.MotorizadaId,
                        principalTable: "Motorizadas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Licencas_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTransacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormacaoReciclagems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificadoNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacaoReciclagems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormacaoReciclagems_Condutors_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormacaoReciclagems_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acidentes_CondutorId",
                table: "Acidentes",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Acidentes_MotorizadaId",
                table: "Acidentes",
                column: "MotorizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Condutors_MunicipioId",
                table: "Condutors",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CondutorId",
                table: "Cursos",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_EscolaId",
                table: "Cursos",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_escolasCoducaos_MunicipioId",
                table: "escolasCoducaos",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalUtilizadors_MunicipioId",
                table: "FiscalUtilizadors",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoReciclagems_CondutorId",
                table: "FormacaoReciclagems",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoReciclagems_CursoId",
                table: "FormacaoReciclagems",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Infracaos_CondutorId",
                table: "Infracaos",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Infracaos_FiscalId",
                table: "Infracaos",
                column: "FiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Infracaos_MotorizadaId",
                table: "Infracaos",
                column: "MotorizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Infracaos_TipoInfracaoId",
                table: "Infracaos",
                column: "TipoInfracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspencaos_FiscalId",
                table: "Inspencaos",
                column: "FiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspencaos_MotorizadaId",
                table: "Inspencaos",
                column: "MotorizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_CondutorId",
                table: "Licencas",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_MotorizadaId",
                table: "Licencas",
                column: "MotorizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_MunicipioId",
                table: "Licencas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorizadas_condutorId",
                table: "Motorizadas",
                column: "condutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ReceitaId",
                table: "Pagamentos",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CondutorId",
                table: "Receitas",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_MunicipioId",
                table: "Receitas",
                column: "MunicipioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acidentes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FormacaoReciclagems");

            migrationBuilder.DropTable(
                name: "Infracaos");

            migrationBuilder.DropTable(
                name: "Inspencaos");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "TiposInfracoes");

            migrationBuilder.DropTable(
                name: "FiscalUtilizadors");

            migrationBuilder.DropTable(
                name: "Motorizadas");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "escolasCoducaos");

            migrationBuilder.DropTable(
                name: "Condutors");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Provicias");
        }
    }
}
