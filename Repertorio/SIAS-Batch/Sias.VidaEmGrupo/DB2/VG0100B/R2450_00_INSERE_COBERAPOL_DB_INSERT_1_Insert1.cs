using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1 : QueryBasis<R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COBERAPOL
            VALUES (:V0COBE-NUM-APOL ,
            :V0COBE-NUM-ENDOS ,
            :V0COBE-NUM-ITEM ,
            :V0COBE-OCORR-HIST ,
            :V0COBE-RAMOFR ,
            :V0COBE-MODALIFR ,
            :V0COBE-COD-COBER ,
            :V0COBE-IMP-SEGUR-I ,
            :V0COBE-PRM-TARIF-I ,
            :V0COBE-IMP-SEGUR-V ,
            :V0COBE-PRM-TARIF-V ,
            :V0COBE-PCT-COBER ,
            :V0COBE-FAT-MULT ,
            :V0COBE-DATA-INIVIG ,
            :V0COBE-DATA-TERVIG ,
            :V0COBE-COD-EMPRESA:VIND-COD-EMP,
            CURRENT TIMESTAMP,
            :V0COBE-COD-SITUACAO:V0COBE-COD-SIT-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERAPOL VALUES ({FieldThreatment(this.V0COBE_NUM_APOL)} , {FieldThreatment(this.V0COBE_NUM_ENDOS)} , {FieldThreatment(this.V0COBE_NUM_ITEM)} , {FieldThreatment(this.V0COBE_OCORR_HIST)} , {FieldThreatment(this.V0COBE_RAMOFR)} , {FieldThreatment(this.V0COBE_MODALIFR)} , {FieldThreatment(this.V0COBE_COD_COBER)} , {FieldThreatment(this.V0COBE_IMP_SEGUR_I)} , {FieldThreatment(this.V0COBE_PRM_TARIF_I)} , {FieldThreatment(this.V0COBE_IMP_SEGUR_V)} , {FieldThreatment(this.V0COBE_PRM_TARIF_V)} , {FieldThreatment(this.V0COBE_PCT_COBER)} , {FieldThreatment(this.V0COBE_FAT_MULT)} , {FieldThreatment(this.V0COBE_DATA_INIVIG)} , {FieldThreatment(this.V0COBE_DATA_TERVIG)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0COBE_COD_EMPRESA))}, CURRENT TIMESTAMP,  {FieldThreatment((this.V0COBE_COD_SIT_I?.ToInt() == -1 ? null : this.V0COBE_COD_SITUACAO))})";

            return query;
        }
        public string V0COBE_NUM_APOL { get; set; }
        public string V0COBE_NUM_ENDOS { get; set; }
        public string V0COBE_NUM_ITEM { get; set; }
        public string V0COBE_OCORR_HIST { get; set; }
        public string V0COBE_RAMOFR { get; set; }
        public string V0COBE_MODALIFR { get; set; }
        public string V0COBE_COD_COBER { get; set; }
        public string V0COBE_IMP_SEGUR_I { get; set; }
        public string V0COBE_PRM_TARIF_I { get; set; }
        public string V0COBE_IMP_SEGUR_V { get; set; }
        public string V0COBE_PRM_TARIF_V { get; set; }
        public string V0COBE_PCT_COBER { get; set; }
        public string V0COBE_FAT_MULT { get; set; }
        public string V0COBE_DATA_INIVIG { get; set; }
        public string V0COBE_DATA_TERVIG { get; set; }
        public string V0COBE_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0COBE_COD_SITUACAO { get; set; }
        public string V0COBE_COD_SIT_I { get; set; }

        public static void Execute(R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1 r2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1)
        {
            var ths = r2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}