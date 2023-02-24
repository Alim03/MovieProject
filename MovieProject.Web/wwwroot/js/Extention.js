function fecthApi(url, method, input)
{
    let options = {
        method: method,
    headers: {
        'Content-Type':
            'application/json;charset=utf-8'
    },
        body: JSON.stringify(input)
}
    let fetchRes = fetch(
        url,
    options);
fetchRes.then(res =>
    res.json()).then(d => {
        return d;
    })
}