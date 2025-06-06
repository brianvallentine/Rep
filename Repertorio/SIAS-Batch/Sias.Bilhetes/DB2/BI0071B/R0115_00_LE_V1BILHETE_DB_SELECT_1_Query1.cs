using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMBIL,
            FONTE,
            CODCLIEN,
            OCORR_ENDERECO,
            SITUACAO,
            RAMO,
            OPC_COBERTURA
            INTO :V1BILH-NUMBIL,
            :V1BILH-FONTE,
            :V1BILH-COD-CLIENTE,
            :V1BILH-OCOREND,
            :V1BILH-SITUACAO,
            :V1BILH-RAMO,
            :V1BILH-OPCAO-COB
            FROM SEGUROS.V0BILHETE
            WHERE NUM_APOLICE = :V1BILH-NUMAPOL
            AND SITUACAO = :V1BILH-SITUACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMBIL
							,
											FONTE
							,
											CODCLIEN
							,
											OCORR_ENDERECO
							,
											SITUACAO
							,
											RAMO
							,
											OPC_COBERTURA
											FROM SEGUROS.V0BILHETE
											WHERE NUM_APOLICE = '{this.V1BILH_NUMAPOL}'
											AND SITUACAO = '{this.V1BILH_SITUACAO}'";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_FONTE { get; set; }
        public string V1BILH_COD_CLIENTE { get; set; }
        public string V1BILH_OCOREND { get; set; }
        public string V1BILH_SITUACAO { get; set; }
        public string V1BILH_RAMO { get; set; }
        public string V1BILH_OPCAO_COB { get; set; }
        public string V1BILH_NUMAPOL { get; set; }

        public static R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 Execute(R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_FONTE = result[i++].Value?.ToString();
            dta.V1BILH_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V1BILH_OCOREND = result[i++].Value?.ToString();
            dta.V1BILH_SITUACAO = result[i++].Value?.ToString();
            dta.V1BILH_RAMO = result[i++].Value?.ToString();
            dta.V1BILH_OPCAO_COB = result[i++].Value?.ToString();
            return dta;
        }

    }
}