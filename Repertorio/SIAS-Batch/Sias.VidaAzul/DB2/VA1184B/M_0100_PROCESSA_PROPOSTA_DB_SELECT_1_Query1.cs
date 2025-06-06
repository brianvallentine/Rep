using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO, FAIXA, LOT_EMP_SEGURADO
            INTO :SEGURA-SIT-REGISTRO,
            :SEGURA-FAIXA,
            :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_APOLICE = :RELATO-NUM-APOLICE
            AND COD_SUBGRUPO = :RELATO-CODSUBES
            AND NUM_CERTIFICADO = :RELATO-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							, FAIXA
							, LOT_EMP_SEGURADO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_APOLICE = '{this.RELATO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.RELATO_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.RELATO_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURA_SIT_REGISTRO { get; set; }
        public string SEGURA_FAIXA { get; set; }
        public string SEGURA_LOT_EMP_SEGURADO { get; set; }
        public string WLOT_EMP_SEGURADO { get; set; }
        public string RELATO_NUM_APOLICE { get; set; }
        public string RELATO_CODSUBES { get; set; }
        public string RELATO_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURA_FAIXA = result[i++].Value?.ToString();
            dta.SEGURA_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.WLOT_EMP_SEGURADO = string.IsNullOrWhiteSpace(dta.SEGURA_LOT_EMP_SEGURADO) ? "-1" : "0";
            return dta;
        }

    }
}