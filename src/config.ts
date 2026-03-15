import * as vscode from 'vscode'
import * as path from 'path'
import * as utils from './utils'
import { UpdateOptions } from './updater'

const dotnetRID = (() => {
    switch (process.platform) {
        case 'linux':
            switch (process.arch) {
                case 'x64': return 'linux-x64'
                case 'arm': return 'linux-arm'
                case 'arm64': return 'linux-arm64'
            }
            break
        case 'win32':
            switch (process.arch) {
                case 'x64': return 'win-x64'
            }
            break
    }
    vscode.window.showErrorMessage(`The current platform ${process.platform}-${process.arch} is not supported`)
    return ''
})()

const executableFileExtension = (() => {
    switch (process.platform) {
        case 'win32':
            return '.exe'
        case 'linux':
        default:
            return ''
    }
})()

export function getConfig() {
    const config = vscode.workspace.getConfiguration(utils.extensionConfigName, vscode.window.activeTextEditor ? (vscode.workspace.getWorkspaceFolder(vscode.window.activeTextEditor.document.uri)?.uri ?? null) : null)
    return Object.freeze({
        runtime: {
            githubUsername: 'BBpezsgo',
            githubRepository: 'BBLang',
            githubAssetName: dotnetRID ? `${dotnetRID}.zip` : '',
            path: config.get<string>('runtime.path', path.join(__dirname, 'runtime', `bblang${executableFileExtension}`)),
            pathConfigKey: 'runtime.path',
        } as UpdateOptions,
        languageServer: {
            githubUsername: 'BBpezsgo',
            githubRepository: 'BBLang-LanguageServer',
            githubAssetName: dotnetRID ? `${dotnetRID}.zip` : '',
            path: config.get<string>('server.path', path.join(__dirname, 'language-server', `bblang_languageserver${executableFileExtension}`)),
            pathConfigKey: 'server.path',
        } as UpdateOptions,
        debugServer: {
            githubUsername: 'BBpezsgo',
            githubRepository: 'BBLang-DebugHost',
            githubAssetName: dotnetRID ? `${dotnetRID}.zip` : '',
            path: config.get<string>('debug.server.path', path.join(__dirname, 'debug-server', `bblang_debughost${executableFileExtension}`)),
            pathConfigKey: 'debug.server.path',
        } as UpdateOptions,
    })
}

export function goToConfig(config: string) {
    vscode.commands.executeCommand('workbench.action.openSettings', `${utils.extensionConfigName}.${config}`)
}
