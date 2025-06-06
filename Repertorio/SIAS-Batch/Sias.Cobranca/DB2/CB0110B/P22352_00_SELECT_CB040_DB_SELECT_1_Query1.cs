using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22352_00_SELECT_CB040_DB_SELECT_1_Query1 : QueryBasis<P22352_00_SELECT_CB040_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_MOVTO),0)
            INTO :CB040-NUM-OCORR-MOVTO
            FROM SEGUROS.CB_PESS_PENDENCIA
            WHERE NUM_APOLICE = :FOLLOUP-NUM-APOLICE
            AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO
            AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_MOVTO)
							,0)
											FROM SEGUROS.CB_PESS_PENDENCIA
											WHERE NUM_APOLICE = '{this.FOLLOUP_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.FOLLOUP_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.FOLLOUP_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string CB040_NUM_OCORR_MOVTO { get; set; }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string FOLLOUP_NUM_ENDOSSO { get; set; }
        public string FOLLOUP_NUM_PARCELA { get; set; }

        public static P22352_00_SELECT_CB040_DB_SELECT_1_Query1 Execute(P22352_00_SELECT_CB040_DB_SELECT_1_Query1 p22352_00_SELECT_CB040_DB_SELECT_1_Query1)
        {
            var ths = p22352_00_SELECT_CB040_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P22352_00_SELECT_CB040_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P22352_00_SELECT_CB040_DB_SELECT_1_Query1();
            var i = 0;
            dta.CB040_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}