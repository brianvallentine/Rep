using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1 : QueryBasis<R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_OBJETO_ECT
            VALUES (:GEOBJECT-NUM-CEP,
            'VP0437B' ,
            :GEOBJECT-COD-FORMULARIO,
            :GEOBJECT-STA-REGISTRO,
            CURRENT TIMESTAMP,
            :GEOBJECT-COD-PRODUTO:VIND-CODPRODUTO,
            :GEOBJECT-NUM-INI-POS-VERSO,
            :GEOBJECT-QTD-PESO-GRAMAS,
            :GEOBJECT-VLR-DECLARADO,
            :GEOBJECT-COD-IDENT-OBJETO,
            :GEOBJECT-DES-OBJETO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES ({FieldThreatment(this.GEOBJECT_NUM_CEP)}, 'VP0437B' , {FieldThreatment(this.GEOBJECT_COD_FORMULARIO)}, {FieldThreatment(this.GEOBJECT_STA_REGISTRO)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_CODPRODUTO?.ToInt() == -1 ? null : this.GEOBJECT_COD_PRODUTO))}, {FieldThreatment(this.GEOBJECT_NUM_INI_POS_VERSO)}, {FieldThreatment(this.GEOBJECT_QTD_PESO_GRAMAS)}, {FieldThreatment(this.GEOBJECT_VLR_DECLARADO)}, {FieldThreatment(this.GEOBJECT_COD_IDENT_OBJETO)}, {FieldThreatment(this.GEOBJECT_DES_OBJETO)})";

            return query;
        }
        public string GEOBJECT_NUM_CEP { get; set; }
        public string GEOBJECT_COD_FORMULARIO { get; set; }
        public string GEOBJECT_STA_REGISTRO { get; set; }
        public string GEOBJECT_COD_PRODUTO { get; set; }
        public string VIND_CODPRODUTO { get; set; }
        public string GEOBJECT_NUM_INI_POS_VERSO { get; set; }
        public string GEOBJECT_QTD_PESO_GRAMAS { get; set; }
        public string GEOBJECT_VLR_DECLARADO { get; set; }
        public string GEOBJECT_COD_IDENT_OBJETO { get; set; }
        public string GEOBJECT_DES_OBJETO { get; set; }

        public static void Execute(R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1 r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1)
        {
            var ths = r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}