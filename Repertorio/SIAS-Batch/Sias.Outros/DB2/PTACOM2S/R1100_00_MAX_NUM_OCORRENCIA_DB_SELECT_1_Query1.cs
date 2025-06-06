using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOM2S
{
    public class R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_DOCACO), 0)
            INTO :SIDOCACO-NUM-OCORR-DOCACO
            FROM SEGUROS.SI_DOCUMENTO_ACOMP
            WHERE COD_FONTE = :SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI
            AND COD_DOCUMENTO = :SIDOCACO-COD-DOCUMENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_DOCACO)
							, 0)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP
											WHERE COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SIDOCACO_DAC_PROTOCOLO_SINI}'
											AND COD_DOCUMENTO = '{this.SIDOCACO_COD_DOCUMENTO}'";

            return query;
        }
        public string SIDOCACO_NUM_OCORR_DOCACO { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_DOCUMENTO { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 Execute(R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIDOCACO_NUM_OCORR_DOCACO = result[i++].Value?.ToString();
            return dta;
        }

    }
}