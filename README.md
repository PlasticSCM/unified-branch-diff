# Unified Plastic SCM Branch diff

<p>
You can extend the actions available for branches (and many other objects) by using the <a href="https://www.plasticscm.com/documentation/gui/plastic-scm-version-control-gui-guide#HowtorunexternaltoolsonPlasticSCMobjects" target="_blank">external tools</a> feature.</p>
<div class="separator" style="clear: both; text-align: center;">
<a href="https://4.bp.blogspot.com/-mW-mDNmoiPA/W-VG4-W87VI/AAAAAAAABEE/kXVIQKxlWiUPhoexOXd25rj1hvm_WloKwCLcBGAs/s1600/unified-diff.gif" imageanchor="1" style="margin-left: 1em; margin-right: 1em;"><img border="0" src="https://4.bp.blogspot.com/-mW-mDNmoiPA/W-VG4-W87VI/AAAAAAAABEE/kXVIQKxlWiUPhoexOXd25rj1hvm_WloKwCLcBGAs/s1600/unified-diff.gif" data-original-width="435" data-original-height="268" alt="Unified diff" title="Unified diff" /></a></div>
<p>
This blogpost explains how to create a custom action to run a <a href="http://www.gnu.org/software/diffutils/manual/html_node/Detailed-Unified.html#Detailed-Unified" target="_blank">unified diff</a> operation for a Plastic SCM branch.</p>
<!--more-->  <p>
Get the external tool from <a href="https://github.com/PlasticSCM/unified-branch-diff/releases/tag/v1" target="_blank">here</a>. And browse the source code <a href="https://github.com/PlasticSCM/unified-branch-diff" target="_blank">here</a>.</p>
<h2>
How does it work?</h2>
<p>
Adding new custom tools to the Plastic SCM GUI is easy.</p>
<p>
As we explain <a href="https://www.plasticscm.com/documentation/gui/plastic-scm-version-control-gui-guide#HowtorunexternaltoolsonPlasticSCMobjects" target="_blank">here</a>, you need to add a new line to the <code class="file">externaltools.conf</code> configuration file:</p>
<pre class="file">branch | Create unified diff for THIS branch | C:\tools\unifiedbranchdiff.exe | @wkpath "@object" "C:\Program Files (x86)\Notepad++\notepad++.exe"
</pre>
<p>
with the following structure:</p>
<ol>
<li>The object you want to target, in this case <samp>branch</samp>.</li>
<li>The title you want to display at the context menu, <samp>Create unified diff for THIS branch</samp>.</li>
<li>The tool you want to execute when the action is clicked, <samp>C:\tools\unifiedbranchdiff.exe</samp>.</li>
<li>The arguments to the tool. We use the <samp>@wkpath</samp> and <samp>@object</samp> that are provided by the Plastic GUI, then the editor tool we want to use to display the unified diff content.</li>
</ol>
<p>
This is a custom action for the Plastic SCM branches, so, you will find it in the branch object context menu:</p>
<div class="separator" style="clear: both; text-align: center;">
<a href="https://3.bp.blogspot.com/-sj-20vDwF2U/W-VCDn-ah6I/AAAAAAAABDg/Rj3uVRvf54AehbuOeLh5gYshGRXcp0MEQCLcBGAs/s1600/context-menu.png" imageanchor="1" style="margin-left: 1em; margin-right: 1em;"><img border="0" src="https://3.bp.blogspot.com/-sj-20vDwF2U/W-VCDn-ah6I/AAAAAAAABDg/Rj3uVRvf54AehbuOeLh5gYshGRXcp0MEQCLcBGAs/s1600/context-menu.png" data-original-width="435" data-original-height="268" alt="Action - Context menu" title="Action - Context menu" /></a></div>
<p>
This action, configured as an "External tool", opens the unified diff for all the changes made on that branch using your favorite editor:</p>
<div class="separator" style="clear: both; text-align: center;">
<a href="https://1.bp.blogspot.com/-BnM9gPc_Ib4/W-VDQHQx-XI/AAAAAAAABDs/uc62BJ7U1L8Y8aKgaldD0Wg6m5agbBzpwCLcBGAs/s1600/notepad%252B%252B.png" imageanchor="1" style="margin-left: 1em; margin-right: 1em;"><img border="0" src="https://1.bp.blogspot.com/-BnM9gPc_Ib4/W-VDQHQx-XI/AAAAAAAABDs/uc62BJ7U1L8Y8aKgaldD0Wg6m5agbBzpwCLcBGAs/s1600/notepad%252B%252B.png" data-original-width="435" data-original-height="268" alt="Action - Context menu" title="Action - Context menu" /></a></div>
<p>
With the unified branch diff in your favorite editor, you are free to review and save it for later use as a report.</p>
<h2>
UnifiedBranchDiff tool</h2>
<p>
This simple tool does two small things:</p>
<ol>
<li>It uses the <kbd>cm path</kbd> command to get a unified diff for the <samp>@object</samp> parameter.</li>
<li>It runs the configured editor with the result of the <kbd>cm path</kbd> command.</li>
</ol>
<p>
You can review the source code. Find the download link at the beginning of this blogpost.</p>
<h3>
cm patch</h3>
<p>
The <kbd>cm patch</kbd> command generates a patch file from a spec or applies a generated patch to the current workspace. It creates a patch file that contains the differences in a branch, a changeset, or the differences between changesets. It will track both the differences of text and binary files.</p>
<p>
The <kbd>--apply</kbd> parameter allows you to apply the contents of a generated patch file to the current workspace.</p>
<p>
This command requires Diff (<a href="http://gnuwin32.sourceforge.net/packages/diffutils.htm" target="_blank">http://gnuwin32.sourceforge.net/packages/diffutils.htm</a>) and Patch (<a href="http://gnuwin32.sourceforge.net/packages/patch.htm" target="_blank">http://gnuwin32.sourceforge.net/packages/patch.htm</a>) tools.  <p>
Once installed, we recommend that you add their location to the <code>PATH</code> environment variable.</p>
<p>
You can also specify the application to use (diff or patch) using the <kbd>cm patch</kbd> <kbd>--tool</kbd> parameter.</p>
