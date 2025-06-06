using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_QUITACAO ,
            FAIXA_RENDA_IND ,
            FAIXA_RENDA_FAM
            INTO
            :PROPOVA-DATA-QUITACAO ,
            :PROPOVA-FAIXA-RENDA-IND
            :VIND-FAIXA-RENDA-IND ,
            :PROPOVA-FAIXA-RENDA-FAM
            :VIND-FAIXA-RENDA-FAM
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            OR NUM_CERTIFICADO = :WHOST-NUM-TERMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_QUITACAO 
							,
											FAIXA_RENDA_IND 
							,
											FAIXA_RENDA_FAM
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											OR NUM_CERTIFICADO = '{this.WHOST_NUM_TERMO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string WHOST_NUM_TERMO { get; set; }

        public static R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 Execute(R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";
            return dta;
        }

    }
}