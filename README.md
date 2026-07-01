# MiniRouteOptimizer

Atividade 02 de **Códigos de Alta Performance** (2º bimestre).

O projeto simula uma cidade como grafo e calcula qual é a rota mais barata entre dois pontos. Também ordena rotas por custo e, se empatar, fica a que tem menos paradas.

Usei como base o material das aulas 16 (ordenação) e 17 (caminho mínimo) que estão no portal.

## O que foi feito

Completei os TODOs da pasta `Services`:

- **CityGraph** - cadastra conexões e consulta vizinhos (usei lista de adjacência com Dictionary)
- **DijkstraService** - menor caminho com Dijkstra e PriorityQueue
- **RouteSorter** - ordena por custo e desempata pelas paradas

Quando não tem caminho entre origem e destino, volta lista vazia e custo `int.MaxValue`.

## Como rodar

Na raiz do projeto:

```bash
dotnet restore
dotnet test
```

Se passar tudo, ta ok.

Console (só mostra a rota de exemplo):

```bash
dotnet run --project src/MiniRouteOptimizer/MiniRouteOptimizer.csproj
```

## Explicação dos conceitos

Pra grafo, cada ponto é um vertice e cada conexão é uma aresta com custo. Guardei num Dictionary onde a chave é o ponto de origem e o valor é a lista de arestas que saem dele.

No Dijkstra começa na origem com custo 0 e vai visitando os vizinhos. A PriorityQueue (heap) sempre tira primeiro o ponto com menor custo acumulado, ai quando chega no destino ja achou o caminho mais barato. Depois reconstruo o caminho vendo quem veio antes de cada ponto.

Na ordenação usei OrderBy no custo total e ThenBy nas paradas. Se duas rotas custam igual, ganha a que passa por menos pontos no meio.

## Estrutura do projeto

- `src/MiniRouteOptimizer/Services/` - grafo, dijkstra e ordenação
- `tests/MiniRouteOptimizer.Tests/` - testes (não mexi neles)

