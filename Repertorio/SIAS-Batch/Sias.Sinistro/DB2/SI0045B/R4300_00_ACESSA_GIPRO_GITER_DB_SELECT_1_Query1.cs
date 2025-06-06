using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1 : QueryBasis<R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_FILIAL,
            B.NOME_DESTINATARIO
            INTO :GEDESTIN-COD-FILIAL,
            :GEDESTIN-NOME-DESTINATARIO
            FROM SEGUROS.SI_MOVIMENTO_SINI A,
            SEGUROS.GE_DESTINATARIO B
            WHERE A.COD_GIAFI = B.COD_FILIAL
            AND A.COD_SUBESTIPULANTE = B.COD_CLIENTE
            AND A.COD_FONTE =
            :SISINACO-COD-FONTE
            AND A.NUM_PROTOCOLO_SINI =
            :SISINACO-NUM-PROTOCOLO-SINI
            AND A.DAC_PROTOCOLO_SINI =
            :SISINACO-DAC-PROTOCOLO-SINI
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_FILIAL
							,
											B.NOME_DESTINATARIO
											FROM SEGUROS.SI_MOVIMENTO_SINI A
							,
											SEGUROS.GE_DESTINATARIO B
											WHERE A.COD_GIAFI = B.COD_FILIAL
											AND A.COD_SUBESTIPULANTE = B.COD_CLIENTE
											AND A.COD_FONTE =
											'{this.SISINACO_COD_FONTE}'
											AND A.NUM_PROTOCOLO_SINI =
											'{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND A.DAC_PROTOCOLO_SINI =
											'{this.SISINACO_DAC_PROTOCOLO_SINI}'
											WITH UR";

            return query;
        }
        public string GEDESTIN_COD_FILIAL { get; set; }
        public string GEDESTIN_NOME_DESTINATARIO { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1 Execute(R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1 r4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1)
        {
            var ths = r4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEDESTIN_COD_FILIAL = result[i++].Value?.ToString();
            dta.GEDESTIN_NOME_DESTINATARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}