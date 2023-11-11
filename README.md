# 'Avaliação de Competências em Desenvolvimento' 
Desenvolvimento do projeto 'Avaliação de Competências em Desenvolvimento'

## Descrição

Desenvolvimento do projeto 'Avaliação de Competências em Desenvolvimento' 
com o propósito de medir minha capacidade em analisar e implementar a 
solução fundamentadas pelos princípios do SOLID, Testes
unitários e performance.

Foi desenvolvido uma Api utilizando Asp.Net Core 6, contendo um end-point que 
realiza o cálculo de investimento em CDB.
Este end-point recebe como parametros de entrada, o valor investido e o prazo 
para os meses (número de meses) de aplicação. 
É aplica a fórmula VF = VI x [1 +(CDI x TB)] de acordo com estes parâmetros e 
retornado um objeto Cdb que contem as propriedades:
  * ValorBruto
  * ValorLiquido
  * ValorDesconto

Os métodos de acesso à API, podem ser feitos pelo sistema em Angular CLI também implementado
neste projeto, onde o usuário informa os parâmetros por meio de uma página(browser) e submete
este formulário. Este acesso também pode ser feitop pela fertramenta POSDTMAN, através de uma 
QueryString contendo os parâmetros de entrada, e também por meio da tela do Swagger disponibilizada 
quando execurta a API.

### Dependências

* NUnit (Testes Unitários)
* ReSharper (Cobertura Código  - Instalado na estação e integrado ao Visual Studio)
* Swashbuckle.* (Swagger)
* dotCover (Cobertura Código - Instalado na estação e integrado ao Visual Studio)

### Execução

Os comandos abixo precisam ser executados em linha de comando, estando no diretório do projeto:
* 'dotnet run' --> para executar a api (CalCDB.Client)
* 'ng serve --open' --> para executar o projeto Angular (CalCDB.Client)
* para executar a cobertura de código, vá ao menuu Extension >> ReSharper >> Unit Tests >> Cover All Tests fron solution

## Autor

* Marco Manhães Júnior
