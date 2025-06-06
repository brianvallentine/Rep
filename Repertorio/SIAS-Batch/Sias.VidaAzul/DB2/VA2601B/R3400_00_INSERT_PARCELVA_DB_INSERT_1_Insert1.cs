using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 : QueryBasis<R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PARCELAS_VIDAZUL
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA,
            :WHOST-DATA-AGENDAMENTO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO,
            :DCLPARCELAS-VIDAZUL.PREMIO-AP,
            :DCLPARCELAS-VIDAZUL.VLMULTA,
            :WHOST-OPCAOPAG,
            :DCLPARCELAS-VIDAZUL.SIT-REGISTRO,
            :DCLPARCELAS-VIDAZUL.OCORR-HISTORICO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELAS_VIDAZUL VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_PARCELA)}, {FieldThreatment(this.WHOST_DATA_AGENDAMENTO)}, {FieldThreatment(this.PROPOFID_VAL_PAGO)}, {FieldThreatment(this.PREMIO_AP)}, {FieldThreatment(this.VLMULTA)}, {FieldThreatment(this.WHOST_OPCAOPAG)}, {FieldThreatment(this.SIT_REGISTRO)}, {FieldThreatment(this.OCORR_HISTORICO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_PARCELA { get; set; }
        public string WHOST_DATA_AGENDAMENTO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PREMIO_AP { get; set; }
        public string VLMULTA { get; set; }
        public string WHOST_OPCAOPAG { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string OCORR_HISTORICO { get; set; }

        public static void Execute(R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1)
        {
            var ths = r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}