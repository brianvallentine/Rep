using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class R7220_00_CONSULTA_NN_DB_SELECT_1_Query1 : QueryBasis<R7220_00_CONSULTA_NN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CANAL_PROPOSTA
            ,NUM_PROPOSTA_CONV
            ,COD_FONTE
            INTO :APOLIAUT-CANAL-PROPOSTA
            ,:APOLIAUT-NUM-PROPOSTA-CONV
            ,:APOLIAUT-COD-FONTE
            FROM SEGUROS.APOLICE_AUTO
            WHERE NUM_APOLICE = :PARC-NUM-APOLICE
            AND NUM_ENDOSSO = :PARC-NRENDOS
            AND NUM_ITEM = 101
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CANAL_PROPOSTA
											,NUM_PROPOSTA_CONV
											,COD_FONTE
											FROM SEGUROS.APOLICE_AUTO
											WHERE NUM_APOLICE = '{this.PARC_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARC_NRENDOS}'
											AND NUM_ITEM = 101
											WITH UR";

            return query;
        }
        public string APOLIAUT_CANAL_PROPOSTA { get; set; }
        public string APOLIAUT_NUM_PROPOSTA_CONV { get; set; }
        public string APOLIAUT_COD_FONTE { get; set; }
        public string PARC_NUM_APOLICE { get; set; }
        public string PARC_NRENDOS { get; set; }

        public static R7220_00_CONSULTA_NN_DB_SELECT_1_Query1 Execute(R7220_00_CONSULTA_NN_DB_SELECT_1_Query1 r7220_00_CONSULTA_NN_DB_SELECT_1_Query1)
        {
            var ths = r7220_00_CONSULTA_NN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7220_00_CONSULTA_NN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7220_00_CONSULTA_NN_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLIAUT_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            dta.APOLIAUT_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}