const { createProxyMiddleware } = require('http-proxy-middleware');
const context = [
    "/events"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7107',
        secure: false,
    });
    app.use(appProxy);
};
