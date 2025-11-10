# FlixUp.API

## Rodar
dotnet restore
dotnet run
# Swagger: http://localhost:5281/swagger

## Autenticação (JWT)
1) POST /api/Auth/login  → retorna { token }
2) No Swagger clique "Authorize" e cole:  Bearer <token>

## Endpoints principais
GET  /api/Conteudos
GET  /api/Conteudos/{id}
GET  /api/Playlists
GET  /api/Playlists/{id}    # retorna usuario, conteudos[], itens[]
POST /api/Playlists
DEL  /api/Playlists/{id}
POST /api/ItensPlaylist
DEL  /api/ItensPlaylist/{id}

## Emulador Android
Base URL: http://10.0.2.2:5281
