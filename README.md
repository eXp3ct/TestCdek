# TestCdek

Для использование необходимо получить Bearer токен авторизации от https://api.edu.cdek.ru/v2/oauth/token c телом POST запроса формата x-www-form-urlencoded
1. grant_type - client_credentials
2. client_id - EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI
3. client_secret - PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG

Далее "access_token" поместить в *appsettings.json* в поле *"CdekApiKey"*
