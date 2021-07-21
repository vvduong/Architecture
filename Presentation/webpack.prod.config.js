const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
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
//            minify: true,
//            chunks: [entryName],
//            template: path.resolve(__dirname, 'assets', 'bundled.html'),
//            title: entryName,
//            filename: 'bundled/${entryName}.html',

//        }));
//    };
//};
module.exports = (env, argv) => {
    return {
        mode: 'production',
        entry: entry,
        output: {
            path: path.resolve(__dirname, distDir),
            publicPath: '/Assets/dist/',
            filename: '[name].bundle.js',
            chunkFilename: '[chunkhash].bundle.js',
        },
        cache: true,
        optimization: {
            minimizer: [new OptimizeCSSAssetsPlugin({})],
            splitChunks: {
                chunks: 'all',
                maxSize: 249856,
                automaticNameDelimiter: '-'
            },
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
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: '[name].css',
                chunkFilename: '[chunkhash].css',
            }),
            new webpack.DefinePlugin({
                'process.env.APP_PATH': JSON.stringify(process.env.APP_PATH || '/'),
                'process.env.DIST_DIR': JSON.stringify(distDir)
            }),

        ].concat(entryHtml),
        resolve: {
            alias: {
                Assets: path.resolve(__dirname, 'assets'),
            }
        },
        externals: {
            jquery: 'jQuery'
        },

    }
};