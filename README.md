### Documentação:

Este documento tem como objetivo disponibilizar um passo a passo de como baixar e executar a aplicação, assim como algumas obersevações. 


### Tecnologias

Foram utilizadas para o desenvolvimento desse pequeno projeto, as tecnologias a seguir:
- SQL SERVER (Banco de dados);
- C#/ .NET 6 (Back-End);
- WPF(Front-End);

### IDE's utilizadas:

- Visual Studio Community

OBS: Vale ressaltar que há a necessidade deter essa IDE para não ter problemas com a execução do projeto.

### Passo a passo
- Primeiramente clona-se o projeto localizado nesta url;
- Após isto há necessidade de navegar até a pasta do projeto e executar a solução dentro do visual studio:
- Após aberto deve-se definir como projeto inicializador o projeto CRUD_WPF_FORM.
- Assim que definido o projeto inicializador deve-se apenas compilar e executar. Por default a url definida no projeto é da API hospedada na AZURE. Entretando caso prefira executar tudo localmente pode-se alterar para utilizar utilizar o projeto API que esta na mesma solução.
- Assim finalizando esse passo a passo.


### Algumas observações:
- Caso decida por alterar a api acessada pelo projeto CRUD_WPF_FORM para local, há necessidade de definir como projetos inicialização ambos projetos da solução.
- O projeto API está definida como string de conexão a conexão com o banco da Azure. Caso decida por rodar o projeto api local e  banco local haverá necessidade de alterar a string de conexão  para a desejada.
- Para facilitar tanto  o banco , quanto a api foram hospedadas na Azure. Dado isso a api se encontra nessa URL: https://api-ideal-soft.azurewebsites.net
- Já foi deixado tudo conectado para necessidade de apenas executar o projeto CRUD_WPF_FORM;
- Caso por algum  motivo de problema em relação a Firewall do ip utilizado com o acesso da azure, me comunique.
