using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1 : QueryBasis<R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_CONV
            ,CANAL_PROPOSTA
            ,COD_FONTE
            INTO :APOLIAUT-NUM-PROPOSTA-CONV
            ,:APOLIAUT-CANAL-PROPOSTA
            ,:APOLIAUT-COD-FONTE
            FROM SEGUROS.APOLICE_AUTO
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NUM_ENDOSSO = :V1PARC-NRENDOS
            AND SIT_REGISTRO = ' '
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_CONV
											,CANAL_PROPOSTA
											,COD_FONTE
											FROM SEGUROS.APOLICE_AUTO
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NUM_ENDOSSO = '{this.V1PARC_NRENDOS}'
											AND SIT_REGISTRO = ' '
											WITH UR";

            return query;
        }
        public string APOLIAUT_NUM_PROPOSTA_CONV { get; set; }
        public string APOLIAUT_CANAL_PROPOSTA { get; set; }
        public string APOLIAUT_COD_FONTE { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1 Execute(R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1 r6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1)
        {
            var ths = r6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLIAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            dta.APOLIAUT_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.APOLIAUT_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}