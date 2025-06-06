using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PARCELAS_VIDAZUL
            ( NUM_CERTIFICADO ,
            NUM_PARCELA ,
            DATA_VENCIMENTO ,
            PREMIO_VG ,
            PREMIO_AP ,
            VLMULTA ,
            OPCAO_PAGAMENTO ,
            SIT_REGISTRO ,
            OCORR_HISTORICO ,
            TIMESTAMP)
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :PARCEVID-NUM-PARCELA,
            :PARCEVID-DATA-VENCIMENTO,
            :PARCEVID-PREMIO-VG,
            :PARCEVID-PREMIO-AP,
            0.0,
            :PARCEVID-OPCAO-PAGAMENTO,
            :PARCEVID-SIT-REGISTRO,
            :PARCEVID-OCORR-HISTORICO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELAS_VIDAZUL ( NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.PARCEVID_NUM_PARCELA)}, {FieldThreatment(this.PARCEVID_DATA_VENCIMENTO)}, {FieldThreatment(this.PARCEVID_PREMIO_VG)}, {FieldThreatment(this.PARCEVID_PREMIO_AP)}, 0.0, {FieldThreatment(this.PARCEVID_OPCAO_PAGAMENTO)}, {FieldThreatment(this.PARCEVID_SIT_REGISTRO)}, {FieldThreatment(this.PARCEVID_OCORR_HISTORICO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string PARCEVID_OPCAO_PAGAMENTO { get; set; }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string PARCEVID_OCORR_HISTORICO { get; set; }

        public static void Execute(R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 r2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}