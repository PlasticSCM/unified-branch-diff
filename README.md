# Unified Plastic SCM Branch diff

You can extend the actions available for branches (and many other objects) by using the [external tools](https://www.plasticscm.com/documentation/gui/plastic-scm-version-control-gui-guide#HowtorunexternaltoolsonPlasticSCMobjects) feature.

> This requires Plastic SCM client version to be **7.0.16.2032 or higher**.

![See it in action](https://4.bp.blogspot.com/-mW-mDNmoiPA/W-VG4-W87VI/AAAAAAAABEE/kXVIQKxlWiUPhoexOXd25rj1hvm_WloKwCLcBGAs/s1600/unified-diff.gif)

This document explains how to create a custom action to run a [unified diff](http://www.gnu.org/software/diffutils/manual/html_node/Detailed-Unified.html#Detailed-Unified) operation for a Plastic SCM branch.

## How does it work

Adding new custom tools to the Plastic SCM GUI is easy.

As we explain [here](https://www.plasticscm.com/documentation/gui/plastic-scm-version-control-gui-guide#HowtorunexternaltoolsonPlasticSCMobjects), you need to add a new line to the `externaltools.conf` configuration file:

```text
branch | Create unified diff for THIS branch | C:\tools\unifiedbranchdiff.exe | @wkpath "@object" "C:\Program Files (x86)\Notepad++\notepad++.exe"
```

...with the following structure:

1. The object you want to target, in this case `branch`.
2. The title you want to display at the context menu, `Create unified diff for THIS branch`.
3. The tool you want to execute when the action is clicked, `C:\tools\unifiedbranchdiff.exe`.
4. The arguments to the tool. We use the `@wkpath` and `@object` that are provided by the Plastic GUI, then the editor tool we want to use to display the unified diff content.

This is a custom action for the Plastic SCM branches, so, you will find it in the branch object context menu:

![Action - Context menu](https://3.bp.blogspot.com/-sj-20vDwF2U/W-VCDn-ah6I/AAAAAAAABDg/Rj3uVRvf54AehbuOeLh5gYshGRXcp0MEQCLcBGAs/s1600/context-menu.png)

This action, configured as an "External tool", opens the unified diff for all the changes made on that branch using your favorite editor:

![Unified diff in text editor](https://1.bp.blogspot.com/-BnM9gPc_Ib4/W-VDQHQx-XI/AAAAAAAABDs/uc62BJ7U1L8Y8aKgaldD0Wg6m5agbBzpwCLcBGAs/s1600/notepad%252B%252B.png)

With the unified branch diff in your favorite editor, you are free to review and save it for later use as a report.</p>

## UnifiedBranchDiff tool

This simple tool does two small things:

- It uses the `cm patch` command to get a unified diff for the `@object` parameter.
- It runs the configured editor with the result of the `cm path` command.

## `cm patch`

The `cm patch` command generates a patch file from a spec or applies a generated patch to the current workspace. It creates a patch file that contains the differences in a branch, a changeset, or the differences between changesets. It will track both the differences of text and binary files.

The `--apply` parameter allows you to apply the contents of a generated patch file to the current workspace.

This command requires [Diff](http://gnuwin32.sourceforge.net/packages/diffutils.htm) and [Patch](http://gnuwin32.sourceforge.net/packages/patch.htm) tools.

Once installed, we recommend that you add their location to the `PATH` environment variable.

You can also specify the application to use (diff or patch) using the `cm patch --tool` parameter.
