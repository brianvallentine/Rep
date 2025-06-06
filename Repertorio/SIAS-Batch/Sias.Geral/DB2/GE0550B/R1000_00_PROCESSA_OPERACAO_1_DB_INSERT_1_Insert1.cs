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
    public class R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1 : QueryBasis<R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_PESS_PENDENCIA
            ( NUM_OCORR_MOVTO,
            NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            DATA_MOVIMENTO,
            HORA_OPERACAO)
            VALUES
            (:CB039-NUM-OCORR-MOVTO,
            :CB039-NUM-APOLICE,
            :CB039-NUM-ENDOSSO,
            :CB039-NUM-PARCELA,
            :CB039-DATA-MOVIMENTO,
            :CB039-HORA-OPERACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_PESS_PENDENCIA ( NUM_OCORR_MOVTO, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DATA_MOVIMENTO, HORA_OPERACAO) VALUES ({FieldThreatment(this.CB039_NUM_OCORR_MOVTO)}, {FieldThreatment(this.CB039_NUM_APOLICE)}, {FieldThreatment(this.CB039_NUM_ENDOSSO)}, {FieldThreatment(this.CB039_NUM_PARCELA)}, {FieldThreatment(this.CB039_DATA_MOVIMENTO)}, {FieldThreatment(this.CB039_HORA_OPERACAO)})";

            return query;
        }
        public string CB039_NUM_OCORR_MOVTO { get; set; }
        public string CB039_NUM_APOLICE { get; set; }
        public string CB039_NUM_ENDOSSO { get; set; }
        public string CB039_NUM_PARCELA { get; set; }
        public string CB039_DATA_MOVIMENTO { get; set; }
        public string CB039_HORA_OPERACAO { get; set; }

        public static void Execute(R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1 r1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1)
        {
            var ths = r1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}