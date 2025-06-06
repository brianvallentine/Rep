using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            01,
            OCORR_ENDERECO,
            NUM_PROPOSTA,
            AGE_COBRANCA,
            RAMO_EMISSOR
            INTO :ENDOSSOS-COD-PRODUTO,
            :ENDOSSOS-COD-MOEDA-PRM,
            :ENDOSSOS-OCORR-ENDERECO,
            :ENDOSSOS-NUM-PROPOSTA,
            :ENDOSSOS-AGE-COBRANCA,
            :ENDOSSOS-RAMO-EMISSOR
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											01
							,
											OCORR_ENDERECO
							,
											NUM_PROPOSTA
							,
											AGE_COBRANCA
							,
											RAMO_EMISSOR
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_AGE_COBRANCA { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 Execute(DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 dB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = dB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB106_ACESSA_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}