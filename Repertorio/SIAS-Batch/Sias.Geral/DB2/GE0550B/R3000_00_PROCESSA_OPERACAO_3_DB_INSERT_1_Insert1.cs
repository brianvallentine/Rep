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
    public class R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1 : QueryBasis<R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_PESS_PARCELA
            ( NUM_OCORR_MOVTO,
            NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            OCORR_HISTORICO)
            VALUES
            (:CB041-NUM-OCORR-MOVTO,
            :CB041-NUM-APOLICE,
            :CB041-NUM-ENDOSSO,
            :CB041-NUM-PARCELA,
            :CB041-OCORR-HISTORICO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_PESS_PARCELA ( NUM_OCORR_MOVTO, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, OCORR_HISTORICO) VALUES ({FieldThreatment(this.CB041_NUM_OCORR_MOVTO)}, {FieldThreatment(this.CB041_NUM_APOLICE)}, {FieldThreatment(this.CB041_NUM_ENDOSSO)}, {FieldThreatment(this.CB041_NUM_PARCELA)}, {FieldThreatment(this.CB041_OCORR_HISTORICO)})";

            return query;
        }
        public string CB041_NUM_OCORR_MOVTO { get; set; }
        public string CB041_NUM_APOLICE { get; set; }
        public string CB041_NUM_ENDOSSO { get; set; }
        public string CB041_NUM_PARCELA { get; set; }
        public string CB041_OCORR_HISTORICO { get; set; }

        public static void Execute(R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1 r3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1)
        {
            var ths = r3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}