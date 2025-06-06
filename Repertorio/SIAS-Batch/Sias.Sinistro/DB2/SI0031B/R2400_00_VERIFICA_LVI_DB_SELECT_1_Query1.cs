using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1 : QueryBasis<R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_EVENTO
            INTO :SIDOCACO-COD-EVENTO
            FROM SEGUROS.SI_DOCUMENTO_ACOMP A
            WHERE A.COD_FONTE = :H-SIDOCACO-COD-FONTE
            AND A.NUM_PROTOCOLO_SINI =
            :H-SIDOCACO-NUM-PROTOCOLO-SINI
            AND A.DAC_PROTOCOLO_SINI =
            :H-SIDOCACO-DAC-PROTOCOLO-SINI
            AND A.COD_DOCUMENTO = 27
            AND A.NUM_OCORR_DOCACO =
            (SELECT MAX(B.NUM_OCORR_DOCACO)
            FROM SEGUROS.SI_DOCUMENTO_ACOMP B
            WHERE A.COD_FONTE = B.COD_FONTE
            AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI
            AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI
            AND A.COD_DOCUMENTO = B.COD_DOCUMENTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_EVENTO
											FROM SEGUROS.SI_DOCUMENTO_ACOMP A
											WHERE A.COD_FONTE = '{this.H_SIDOCACO_COD_FONTE}'
											AND A.NUM_PROTOCOLO_SINI =
											'{this.H_SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND A.DAC_PROTOCOLO_SINI =
											'{this.H_SIDOCACO_DAC_PROTOCOLO_SINI}'
											AND A.COD_DOCUMENTO = 27
											AND A.NUM_OCORR_DOCACO =
											(SELECT MAX(B.NUM_OCORR_DOCACO)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP B
											WHERE A.COD_FONTE = B.COD_FONTE
											AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI
											AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI
											AND A.COD_DOCUMENTO = B.COD_DOCUMENTO)";

            return query;
        }
        public string SIDOCACO_COD_EVENTO { get; set; }
        public string H_SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_COD_FONTE { get; set; }

        public static R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1 Execute(R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1 r2400_00_VERIFICA_LVI_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_VERIFICA_LVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIDOCACO_COD_EVENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}