using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7419_GE1_INSERT_DB_INSERT_1_Insert1 : QueryBasis<P7419_GE1_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_MOVTO_TRIBUTO (
            NUM_ID_ENVIO
            ,SEQ_ID_ENVIO_HIST
            ,COD_IMPOSTO_INTERNO
            ,COD_TRIBUTO_SAP
            ,IND_TP_TRIBUTO
            ,PCT_ALIQUOTA
            ,VLR_BASE_TRIB
            ,VLR_TRIBUTO
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO
            )
            VALUES (
            :GE419-NUM-ID-ENVIO
            ,:GE419-SEQ-ID-ENVIO-HIST
            ,:GE419-COD-IMPOSTO-INTERNO
            ,:GE419-COD-TRIBUTO-SAP
            ,:GE419-IND-TP-TRIBUTO
            ,:GE419-PCT-ALIQUOTA
            :WH-ALICOTA-NULL
            ,:GE419-VLR-BASE-TRIB
            ,:GE419-VLR-TRIBUTO
            :WH-TRIBUTO-NULL
            , 'SICP001S'
            , CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVTO_TRIBUTO ( NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,COD_IMPOSTO_INTERNO ,COD_TRIBUTO_SAP ,IND_TP_TRIBUTO ,PCT_ALIQUOTA ,VLR_BASE_TRIB ,VLR_TRIBUTO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.GE419_NUM_ID_ENVIO)} ,{FieldThreatment(this.GE419_SEQ_ID_ENVIO_HIST)} ,{FieldThreatment(this.GE419_COD_IMPOSTO_INTERNO)} ,{FieldThreatment(this.GE419_COD_TRIBUTO_SAP)} ,{FieldThreatment(this.GE419_IND_TP_TRIBUTO)} , {FieldThreatment((this.WH_ALICOTA_NULL?.ToInt() == -1 ? null : this.GE419_PCT_ALIQUOTA))} ,{FieldThreatment(this.GE419_VLR_BASE_TRIB)} , {FieldThreatment((this.WH_TRIBUTO_NULL?.ToInt() == -1 ? null : this.GE419_VLR_TRIBUTO))} , 'SICP001S' , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE419_NUM_ID_ENVIO { get; set; }
        public string GE419_SEQ_ID_ENVIO_HIST { get; set; }
        public string GE419_COD_IMPOSTO_INTERNO { get; set; }
        public string GE419_COD_TRIBUTO_SAP { get; set; }
        public string GE419_IND_TP_TRIBUTO { get; set; }
        public string GE419_PCT_ALIQUOTA { get; set; }
        public string WH_ALICOTA_NULL { get; set; }
        public string GE419_VLR_BASE_TRIB { get; set; }
        public string GE419_VLR_TRIBUTO { get; set; }
        public string WH_TRIBUTO_NULL { get; set; }

        public static void Execute(P7419_GE1_INSERT_DB_INSERT_1_Insert1 p7419_GE1_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = p7419_GE1_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7419_GE1_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}