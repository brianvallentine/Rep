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
    public class R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_PESS_SINISTRO
            ( NUM_OCORR_MOVTO,
            NUM_APOL_SINISTRO,
            OCORR_HISTORICO,
            COD_OPERACAO)
            VALUES
            (:SI175-NUM-OCORR-MOVTO,
            :SI175-NUM-APOL-SINISTRO,
            :SI175-OCORR-HISTORICO,
            :SI175-COD-OPERACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_PESS_SINISTRO ( NUM_OCORR_MOVTO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO) VALUES ({FieldThreatment(this.SI175_NUM_OCORR_MOVTO)}, {FieldThreatment(this.SI175_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SI175_OCORR_HISTORICO)}, {FieldThreatment(this.SI175_COD_OPERACAO)})";

            return query;
        }
        public string SI175_NUM_OCORR_MOVTO { get; set; }
        public string SI175_NUM_APOL_SINISTRO { get; set; }
        public string SI175_OCORR_HISTORICO { get; set; }
        public string SI175_COD_OPERACAO { get; set; }

        public static void Execute(R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1 r4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}