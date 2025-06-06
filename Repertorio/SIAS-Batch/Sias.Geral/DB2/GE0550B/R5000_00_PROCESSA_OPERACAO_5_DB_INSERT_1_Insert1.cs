using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1 : QueryBasis<R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_PESS_PARCELA
            ( NUM_OCORR_MOVTO,
            NUM_CERTIFICADO,
            NUM_PARCELA,
            NUM_TITULO)
            VALUES
            (:VG079-NUM-OCORR-MOVTO,
            :VG079-NUM-CERTIFICADO,
            :VG079-NUM-PARCELA,
            :VG079-NUM-TITULO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_PESS_PARCELA ( NUM_OCORR_MOVTO, NUM_CERTIFICADO, NUM_PARCELA, NUM_TITULO) VALUES ({FieldThreatment(this.VG079_NUM_OCORR_MOVTO)}, {FieldThreatment(this.VG079_NUM_CERTIFICADO)}, {FieldThreatment(this.VG079_NUM_PARCELA)}, {FieldThreatment(this.VG079_NUM_TITULO)})";

            return query;
        }
        public string VG079_NUM_OCORR_MOVTO { get; set; }
        public string VG079_NUM_CERTIFICADO { get; set; }
        public string VG079_NUM_PARCELA { get; set; }
        public string VG079_NUM_TITULO { get; set; }

        public static void Execute(R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1 r5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1)
        {
            var ths = r5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}