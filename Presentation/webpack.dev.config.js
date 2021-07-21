const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const distDir = process.env.DIST_DIR || 'assets/dist';
const entry = {
    'main': [path.resolve(__dirname, 'assets', 'scripts', 'modules', 'main', 'main.js')],
};
const entryHtml = [];
//for (const entryName in entry) {
//    if (entry.hasOwnProperty(entryName)) {
//        entryHtml.push(new HtmlWebpackPlugin({
//            inject: false,
//            hash: true,
//            chunks: [entryName],
//            template: path.resolve(__dirname, 'assets', 'bundled.html'),
//            title: entryName,
//            filename: 'bundled/${entryName}.html',

//        }));
//    };
//};
module.exports = (env, argv) => {
    return {
        mode: 'development',
        entry: entry,
        output: {
            path: path.resolve(__dirname, distDir),
            publicPath: '/Assets/dist/',
            filename: '[name].js',
            chunkFilename: '[chunkhash].js',
        },
        module: {
            rules: [
                { test: /\.js$/, use: 'babel-loader' },
                {
                    test: /\.css$/i,
                    use: [MiniCssExtractPlugin.loader, 'css-loader']
                }
            ]
        },
        plugins: [
            // new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: '[name].css',
            }),
            new webpack.DefinePlugin({
                'process.env.APP_PATH': JSON.stringify(process.env.APP_PATH || '/'),
                'process.env.DIST_DIR': JSON.stringify(distDir)
            }),
            new webpack.HotModuleReplacementPlugin(),

        ].concat(entryHtml),
        resolve: {
            alias: {
                Assets: path.resolve(__dirname, 'assets'),
            }
        },
        externals: {
            jquery: 'jQuery'
        },
        devServer: {
            writeToDisk: true,
            hot: true,
            //proxy: {
            //    context: () => true,
            //    target: 'http://localhost:50843'
            //}
        },
    }
};