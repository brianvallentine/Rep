using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1 : QueryBasis<R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_IDLG, ' ' )
            INTO :GE403-NUM-IDLG
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
            WHERE NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            AND NUM_APOLICE = :GE403-NUM-APOLICE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_IDLG
							, ' ' )
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
											WHERE NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											AND NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE403_NUM_IDLG { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }
        public string GE403_NUM_APOLICE { get; set; }

        public static R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1 Execute(R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1 r0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1)
        {
            var ths = r0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_NUM_IDLG = result[i++].Value?.ToString();
            return dta;
        }

    }
}