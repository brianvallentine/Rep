using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 : QueryBasis<R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COBERAPOL
            VALUES (:V0COBA-NUM-APOL ,
            :V0COBA-NRENDOS ,
            :V0COBA-NUM-ITEM ,
            :V0COBA-OCORHIST ,
            :V0COBA-RAMOFR ,
            :V0COBA-MODALIFR ,
            :V0COBA-COD-COBER ,
            :V0COBA-IMP-SEG-IX ,
            :V0COBA-PRM-TAR-IX ,
            :V0COBA-IMP-SEG-VR ,
            :V0COBA-PRM-TAR-VR ,
            :V0COBA-PCT-COBERT ,
            :V0COBA-FATOR-MULT ,
            :V0COBA-DATA-INIVI ,
            :V0COBA-DATA-TERVI ,
            :V0COBA-COD-EMPRESA,
            CURRENT TIMESTAMP ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERAPOL VALUES ({FieldThreatment(this.V0COBA_NUM_APOL)} , {FieldThreatment(this.V0COBA_NRENDOS)} , {FieldThreatment(this.V0COBA_NUM_ITEM)} , {FieldThreatment(this.V0COBA_OCORHIST)} , {FieldThreatment(this.V0COBA_RAMOFR)} , {FieldThreatment(this.V0COBA_MODALIFR)} , {FieldThreatment(this.V0COBA_COD_COBER)} , {FieldThreatment(this.V0COBA_IMP_SEG_IX)} , {FieldThreatment(this.V0COBA_PRM_TAR_IX)} , {FieldThreatment(this.V0COBA_IMP_SEG_VR)} , {FieldThreatment(this.V0COBA_PRM_TAR_VR)} , {FieldThreatment(this.V0COBA_PCT_COBERT)} , {FieldThreatment(this.V0COBA_FATOR_MULT)} , {FieldThreatment(this.V0COBA_DATA_INIVI)} , {FieldThreatment(this.V0COBA_DATA_TERVI)} , {FieldThreatment(this.V0COBA_COD_EMPRESA)}, CURRENT TIMESTAMP , NULL)";

            return query;
        }
        public string V0COBA_NUM_APOL { get; set; }
        public string V0COBA_NRENDOS { get; set; }
        public string V0COBA_NUM_ITEM { get; set; }
        public string V0COBA_OCORHIST { get; set; }
        public string V0COBA_RAMOFR { get; set; }
        public string V0COBA_MODALIFR { get; set; }
        public string V0COBA_COD_COBER { get; set; }
        public string V0COBA_IMP_SEG_IX { get; set; }
        public string V0COBA_PRM_TAR_IX { get; set; }
        public string V0COBA_IMP_SEG_VR { get; set; }
        public string V0COBA_PRM_TAR_VR { get; set; }
        public string V0COBA_PCT_COBERT { get; set; }
        public string V0COBA_FATOR_MULT { get; set; }
        public string V0COBA_DATA_INIVI { get; set; }
        public string V0COBA_DATA_TERVI { get; set; }
        public string V0COBA_COD_EMPRESA { get; set; }

        public static void Execute(R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1)
        {
            var ths = r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}