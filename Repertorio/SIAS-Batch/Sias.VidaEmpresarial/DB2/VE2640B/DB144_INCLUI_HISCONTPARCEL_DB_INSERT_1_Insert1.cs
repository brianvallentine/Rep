using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1 : QueryBasis<DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_CONT_PARCELVA
            (NUM_CERTIFICADO,
            NUM_PARCELA ,
            NUM_TITULO ,
            OCORR_HISTORICO,
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_FONTE ,
            NUM_ENDOSSO ,
            PREMIO_VG ,
            PREMIO_AP ,
            DATA_MOVIMENTO ,
            SIT_REGISTRO ,
            COD_OPERACAO ,
            TIMESTAMP ,
            DTFATUR)
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            :PROPOVA-NUM-PARCELA,
            :HISCONPA-NUM-TITULO,
            :HISCONPA-OCORR-HISTORICO,
            :VGSOLFAT-NUM-APOLICE,
            :VGSOLFAT-COD-SUBGRUPO,
            :SUBGVGAP-COD-FONTE,
            :HISCONPA-NUM-ENDOSSO,
            :HISCONPA-PREMIO-VG,
            :HISCONPA-PREMIO-AP,
            :H-DT-MOV-ABERTO-2610,
            :HISCONPA-SIT-REGISTRO,
            :HISCONPA-COD-OPERACAO,
            CURRENT TIMESTAMP,
            :HISCONPA-DTFATUR :N-HISCONPA-DTFATUR )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_CONT_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO, NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_ENDOSSO , PREMIO_VG , PREMIO_AP , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , TIMESTAMP , DTFATUR) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.HISCONPA_NUM_TITULO)}, {FieldThreatment(this.HISCONPA_OCORR_HISTORICO)}, {FieldThreatment(this.VGSOLFAT_NUM_APOLICE)}, {FieldThreatment(this.VGSOLFAT_COD_SUBGRUPO)}, {FieldThreatment(this.SUBGVGAP_COD_FONTE)}, {FieldThreatment(this.HISCONPA_NUM_ENDOSSO)}, {FieldThreatment(this.HISCONPA_PREMIO_VG)}, {FieldThreatment(this.HISCONPA_PREMIO_AP)}, {FieldThreatment(this.H_DT_MOV_ABERTO_2610)}, {FieldThreatment(this.HISCONPA_SIT_REGISTRO)}, {FieldThreatment(this.HISCONPA_COD_OPERACAO)}, CURRENT TIMESTAMP,  {FieldThreatment((this.N_HISCONPA_DTFATUR?.ToInt() == -1 ? null : this.HISCONPA_DTFATUR))} )";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string H_DT_MOV_ABERTO_2610 { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string HISCONPA_DTFATUR { get; set; }
        public string N_HISCONPA_DTFATUR { get; set; }

        public static void Execute(DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1 dB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1)
        {
            var ths = dB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}