using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1 : QueryBasis<R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PLANOS_VGAP
            VALUES (:PLANOVGA-NUM-APOLICE ,
            :PLANOVGA-COD-SUBGRUPO ,
            :PLANOVGA-COD-PLANO ,
            :PLANOVGA-DATA-INIVIGENCIA ,
            :PLANOVGA-IMP-MORNATU ,
            :PLANOVGA-IMP-MORACID ,
            :PLANOVGA-IMP-INVPERM ,
            :PLANOVGA-IMP-AMDS ,
            :PLANOVGA-IMP-DH ,
            :PLANOVGA-IMP-DIT ,
            :PLANOVGA-SIT-REGISTRO ,
            NULL ,
            :PLANOVGA-DATA-TERVIGENCIA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PLANOS_VGAP VALUES ({FieldThreatment(this.PLANOVGA_NUM_APOLICE)} , {FieldThreatment(this.PLANOVGA_COD_SUBGRUPO)} , {FieldThreatment(this.PLANOVGA_COD_PLANO)} , {FieldThreatment(this.PLANOVGA_DATA_INIVIGENCIA)} , {FieldThreatment(this.PLANOVGA_IMP_MORNATU)} , {FieldThreatment(this.PLANOVGA_IMP_MORACID)} , {FieldThreatment(this.PLANOVGA_IMP_INVPERM)} , {FieldThreatment(this.PLANOVGA_IMP_AMDS)} , {FieldThreatment(this.PLANOVGA_IMP_DH)} , {FieldThreatment(this.PLANOVGA_IMP_DIT)} , {FieldThreatment(this.PLANOVGA_SIT_REGISTRO)} , NULL , {FieldThreatment(this.PLANOVGA_DATA_TERVIGENCIA)} )";

            return query;
        }
        public string PLANOVGA_NUM_APOLICE { get; set; }
        public string PLANOVGA_COD_SUBGRUPO { get; set; }
        public string PLANOVGA_COD_PLANO { get; set; }
        public string PLANOVGA_DATA_INIVIGENCIA { get; set; }
        public string PLANOVGA_IMP_MORNATU { get; set; }
        public string PLANOVGA_IMP_MORACID { get; set; }
        public string PLANOVGA_IMP_INVPERM { get; set; }
        public string PLANOVGA_IMP_AMDS { get; set; }
        public string PLANOVGA_IMP_DH { get; set; }
        public string PLANOVGA_IMP_DIT { get; set; }
        public string PLANOVGA_SIT_REGISTRO { get; set; }
        public string PLANOVGA_DATA_TERVIGENCIA { get; set; }

        public static void Execute(R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1 r0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1)
        {
            var ths = r0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}