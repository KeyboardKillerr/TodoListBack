# ��. ������ �� ������ https://aka.ms/customizecontainer, ����� ������ ��� ��������� ��������� ������� � ��� Visual Studio ���������� ���� Dockerfile ��� �������� ������� ��� ��������� �������.

# ���� ���� ������������ ��� ������� �� VS � ������� ������ (�� ��������� ��� ������������ �������)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

# ���� ���� ������������ ��� ������ ������� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TodoList/TodoList.csproj", "TodoList/"]
RUN dotnet restore "./TodoList/TodoList.csproj"
COPY . .
WORKDIR "/src/TodoList"
RUN dotnet build "./TodoList.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ���� ���� ������������ ��� ���������� ������� ������, ������� ����� ���������� �� ��������� ����
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TodoList.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ���� ���� ������������ � ������� ����� ��� ��� ������� �� VS � ������� ������ (�� ���������, ����� ������������ ������� �� ������������)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoList.dll"]  