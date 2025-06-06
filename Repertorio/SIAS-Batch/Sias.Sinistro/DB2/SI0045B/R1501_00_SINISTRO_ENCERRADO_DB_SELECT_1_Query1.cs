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
    public class R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1 : QueryBasis<R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FASE
            INTO :WHOST-COD-FASE
            FROM SEGUROS.SI_SINISTRO_FASE
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            AND NUM_OCORR_SINIACO =
            (SELECT MAX(NUM_OCORR_SINIACO)
            FROM SEGUROS.SI_SINISTRO_FASE E
            WHERE E.COD_FONTE = :SISINACO-COD-FONTE
            AND E.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND E.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FASE
											FROM SEGUROS.SI_SINISTRO_FASE
											WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
											AND NUM_OCORR_SINIACO =
											(SELECT MAX(NUM_OCORR_SINIACO)
											FROM SEGUROS.SI_SINISTRO_FASE E
											WHERE E.COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND E.NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND E.DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}')
											WITH UR";

            return query;
        }
        public string WHOST_COD_FASE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1 Execute(R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1 r1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1)
        {
            var ths = r1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COD_FASE = result[i++].Value?.ToString();
            return dta;
        }

    }
}