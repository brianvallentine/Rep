using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1 : QueryBasis<R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.SI_SINISTRO_ACOMP
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            AND NUM_OCORR_SINIACO = :SISINACO-NUM-OCORR-SINIACO
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.SI_SINISTRO_ACOMP
				WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
				AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
				AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
				AND NUM_OCORR_SINIACO = '{this.SISINACO_NUM_OCORR_SINIACO}'";

            return query;
        }
        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_NUM_OCORR_SINIACO { get; set; }

        public static void Execute(R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1 r2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1)
        {
            var ths = r2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}