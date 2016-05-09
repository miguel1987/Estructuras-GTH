(function (global, undefined) {
    var telerikDemo = global.telerikDemo = {
        showToolTip: function (sender) {
            var tooltipManager = $find(telerikDemo.tooltipManagerID);

            //If the user hovers the image before the page has loaded, there is no manager created
            if (!tooltipManager) return;

            //Find the tooltip for this element if it has been created 
            var tooltip = tooltipManager.getToolTipByElement(sender);

            //Create a tooltip if no tooltip exists for such element
            if (!tooltip) {
                tooltip = tooltipManager.createToolTip(sender);
                var longValue = sender.getAttribute("ID");
                var neededValue = longValue.substring(longValue.indexOf('_') + 1)
                tooltip.set_value(neededValue);
                setTimeout(function () {
                    tooltip.show();
                }, 10);
            }
        }
    }

    function serverID(name, id) {
        telerikDemo[name] = id;
    }

    global.serverID = serverID;
})(window);