using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1 : QueryBasis<M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PARCELAS_VIDAZUL
            (NUM_CERTIFICADO ,
            NUM_PARCELA ,
            DATA_VENCIMENTO ,
            PREMIO_VG ,
            PREMIO_AP ,
            VLMULTA ,
            OPCAO_PAGAMENTO ,
            SIT_REGISTRO ,
            OCORR_HISTORICO ,
            TIMESTAMP)
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            :PROPOVA-NUM-PARCELA,
            :PROPOVA-DATA-VENCIMENTO,
            :HISCOBPR-PRMVG,
            :HISCOBPR-PRMAP,
            0.0,
            :PARCEVID-OPCAO-PAGAMENTO,
            :PARCEVID-SIT-REGISTRO,
            :PARCEVID-OCORR-HISTORICO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELAS_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.PROPOVA_DATA_VENCIMENTO)}, {FieldThreatment(this.HISCOBPR_PRMVG)}, {FieldThreatment(this.HISCOBPR_PRMAP)}, 0.0, {FieldThreatment(this.PARCEVID_OPCAO_PAGAMENTO)}, {FieldThreatment(this.PARCEVID_SIT_REGISTRO)}, {FieldThreatment(this.PARCEVID_OCORR_HISTORICO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string PARCEVID_OPCAO_PAGAMENTO { get; set; }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string PARCEVID_OCORR_HISTORICO { get; set; }

        public static void Execute(M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1 m_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}